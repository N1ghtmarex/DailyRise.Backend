namespace Application.Users.Dtos;

/// <summary>
/// Модель пользователя
/// </summary>
public class UserViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; init; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; init; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public required DateTimeOffset CreatedAt { get; init; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public required DateTimeOffset? UpdatedAt { get; init; }

    /// <summary>
    /// Идентификатор в Telegram
    /// </summary>
    public required long TelegramId { get; init; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    public required bool IsArchive { get; init; }
}
