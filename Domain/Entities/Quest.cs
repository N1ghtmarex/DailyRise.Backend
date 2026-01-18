using Domain.Abstractions;
using Domain.Enums;

namespace Domain.Entities;

public class Quest : BaseEntity<Ulid>, IHasArchiveTrack, IHasTrackDateAttribute
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
    /// Опыт за выполнение
    /// </summary>
    public required int ExperienceReward { get; set; }

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
    public ICollection<ChallengeQuestBind>? ChallngeQuests { get; set; }
}
