using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

/// <summary>
/// Вызов
/// </summary>
public class Challenge : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
{
    /// <summary>
    /// Наименование
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Дата начала
    /// </summary>
    public required DateTimeOffset StartDate { get; set; }

    /// <summary>
    /// Дата окончания
    /// </summary>
    public required DateTimeOffset EndDate { get; set; }

    /// <summary>
    /// Опыт за выполнение
    /// </summary>
    public required int ExperienceReward { get; set; }
    
    /// <summary>
    /// Категория
    /// </summary>
    public required ChallengeCategory Category { get; set; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    public Ulid? AuthorId { get; set; }

    /// <summary>
    /// Автор
    /// </summary>
    public User? Author { get; set; }

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

    /// <summary>
    /// Ссылка на задания вызова
    /// </summary>
    public ICollection<ChallengeQuestBind>? ChallengeQuests { get; set; }

    /// <summary>
    /// Ссылка на вызовы пользователя
    /// </summary>
    public ICollection<UserChallengeBind>? UserChallenges { get; set; }
}
