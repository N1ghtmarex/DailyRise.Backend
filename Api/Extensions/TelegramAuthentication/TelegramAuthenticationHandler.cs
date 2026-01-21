using Api.Extensions.TelegramAuthentication.Models;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Api.Extensions.TelegramAuthentication;

public class TelegramAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IConfiguration _configuration;

    public TelegramAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IConfiguration configuration)
        : base(options, logger, encoder, clock)
    {
        _configuration = configuration;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.NoResult();
        }

        var authHeader = Request.Headers["Authorization"].ToString();

        if (!authHeader.StartsWith("TMiniApp ", StringComparison.OrdinalIgnoreCase))
        {
            return AuthenticateResult.NoResult();
        }

        try
        {
            // Извлекаем параметры из заголовка
            var encodedParams = authHeader["TMiniApp ".Length..];
            var decodedParams = WebUtility.UrlDecode(encodedParams);

            // Парсим параметры
            var authData = ParseAuthHeader(decodedParams);

            // Проверяем подпись (рекомендуется реализовать проверку hash по алгоритму Telegram)
            if (!await ValidateTelegramAuth(authData))
            {
                return AuthenticateResult.Fail("Invalid Telegram signature");
            }

            // Проверяем, не устарели ли данные (более 24 часов)
            var authDateTime = DateTimeOffset.FromUnixTimeSeconds(authData.AuthDate);
            if (DateTimeOffset.UtcNow - authDateTime > TimeSpan.FromHours(24))
            {
                return AuthenticateResult.Fail("Auth data expired");
            }

            // Создаем claims для пользователя
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, authData.User.Id.ToString()),
                new Claim(ClaimTypes.Name, authData.User.FirstName),
                new Claim("TelegramId", authData.User.Id.ToString()),
                new Claim("Username", authData.User.Username ?? ""),
                new Claim("FirstName", authData.User.FirstName ?? ""),
                new Claim("LastName", authData.User.LastName ?? ""),
                new Claim("LanguageCode", authData.User.LanguageCode ?? ""),
                new Claim("PhotoUrl", authData.User.PhotoUrl ?? ""),
                new Claim("ChatInstance", authData.ChatInstance),
                new Claim("ChatType", authData.ChatType),
                new Claim("AuthDate", authData.AuthDate.ToString())
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
        catch (Exception ex)
        {
            return AuthenticateResult.Fail($"Authentication failed: {ex.Message}");
        }
    }

    private TelegramAuthHeader ParseAuthHeader(string header)
    {
        var parameters = header.Split('&')
            .Select(p => p.Split('='))
            .ToDictionary(p => p[0], p => p.Length > 1 ? p[1] : "");

        var authHeader = new TelegramAuthHeader
        {
            User = JsonSerializer.Deserialize<TelegramAuthData>(parameters["user"]),
            ChatInstance = parameters["chat_instance"],
            ChatType = parameters["chat_type"],
            AuthDate = long.Parse(parameters["auth_date"]),
            Signature = parameters.GetValueOrDefault("signature"),
            Hash = parameters.GetValueOrDefault("hash")
        };

        return authHeader;
    }

    private async Task<bool> ValidateTelegramAuth(TelegramAuthHeader authData)
    {
        // Реализация проверки hash по алгоритму Telegram
        // Для проверки нужен секретный токен бота

        var botToken = _configuration["TelegramMiniAppAuthorizationOptions:Token"];

        // Собираем все параметры, кроме hash
        var checkString = $"auth_date={authData.AuthDate}\n" +
                         $"chat_instance={authData.ChatInstance}\n" +
                         $"chat_type={authData.ChatType}\n" +
                         $"user={JsonSerializer.Serialize(authData.User)}";

        // Вычисляем HMAC-SHA256
        using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(botToken));
        var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(checkString));
        var computedHash = BitConverter.ToString(hashBytes)
            .Replace("-", "")
            .ToLower();

        // Сравниваем с полученным hash
        return computedHash == authData.Hash;
    }
}
