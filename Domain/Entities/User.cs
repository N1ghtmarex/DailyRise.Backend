using Domain.Abstractions;

namespace Domain.Entities;

/// <summary>
/// Сущность "Пользователь"
/// </summary>
public class User : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
{
    /// <summary>
    /// Идентификатор пользователя в Telegram
    /// </summary>
    public required long TelegramId { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string? Username { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string? Firstname { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string? Lastname { get; set; }
    
    /// <summary>
    /// Созданные испытания
    /// </summary>
    public ICollection<Challenge>? CreatedChallenges { get; set; }

    /// <summary>
    /// Участие в испытаниях
    /// </summary>
    public ICollection<UserChallengeBind>? ParticipatingChallenges { get; set; }

    /// <summary>
    /// Отметки испытаний
    /// </summary>
    public ICollection<UserChallengeCheckIn>? ChallengeCheckIns { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Дата изменения
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    public bool IsArchive { get; set; }
}
