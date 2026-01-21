using Application.Users.Commands;
using Application.Users.Dtos;
using Application.Users.Queries;
using Core.EntityFramework.Features.SearchPagination.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TgMiniAppAuth;
using TgMiniAppAuth.AuthContext.User;

namespace Api.Controllers;

[ApiController]
[Route("api/user")]
[Authorize(AuthenticationSchemes = TgMiniAppAuthConstants.AuthenticationScheme)]
public class UserController(ISender sender, ITelegramUserAccessor telegramUserAccessor) : ControllerBase
{
    /// <summary>
    /// Добавление пользователя
    /// </summary>
    /// <param name="command">Тело запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Ulid> CreateUser([FromQuery] CreateUserCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение конкретного пользователя
    /// </summary>
    /// <param name="query">Тело запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("{Username}")]
    public async Task<UserViewModel> GetUser([FromQuery] GetUserQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    /// <summary>
    /// Получение данных из Telegram
    /// </summary>
    /// <returns></returns>
    [HttpGet("telegram")]
    public IActionResult GetUser()
    {
        return Ok(telegramUserAccessor.User);
    }

    /// <summary>
    /// Получение списка пользователей
    /// </summary>
    /// <param name="query">Тело запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedResult<UserListViewModel>> GetUsers([FromQuery] GetUserListQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}
