namespace Application.Users.Dtos;

/// <summary>
/// Модель добавления пользователя
/// </summary>
public class CreateUserModel
{
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// Идентификатор в Telegram
    /// </summary>
    public required long TelegramId { get; set; }
}
