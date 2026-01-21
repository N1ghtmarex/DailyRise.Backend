using Domain.Abstractions;

namespace Domain.Entities;

/// <summary>
/// Сущность "Испытание"
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
    /// Идентификатор создателя
    /// </summary>
    public required Ulid AuthorId { get; set; }

    /// <summary>
    /// Создатель
    /// </summary>
    public User? Author { get; set; }

    public ICollection<UserChallengeBind>? Participants { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// Статус архивности
    /// </summary>
    public bool IsArchive { get; set; }
}
