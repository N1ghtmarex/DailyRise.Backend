using Domain.Abstractions;

namespace Domain.Entities;

/// <summary>
/// Профиль
/// </summary>
public class Profile : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Ulid UserId { get; init; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; init; }

    /// <summary>
    /// Уровень
    /// </summary>
    public required int Level { get; set; } = 1;

    /// <summary>
    /// Текущий опыт
    /// </summary>
    public required long Experience { get; set; } = 0;

    /// <summary>
    /// Опыт, необходимый до следующего уровня
    /// </summary>
    public long ExperienceToNextLevel { get; set; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    public bool IsArchive { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Дата изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }
}
