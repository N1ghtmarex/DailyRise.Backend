namespace Application.Users.Dtos;

/// <summary>
/// Модель добавления пользователя
/// </summary>
public class CreateUserModel
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public required string Firstname { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string? Lastname  { get; set; }

    /// <summary>
    /// Идентификатор в Telegram
    /// </summary>
    public required long TelegramId { get; set; }
}
