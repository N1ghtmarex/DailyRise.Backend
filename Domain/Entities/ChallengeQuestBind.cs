namespace Domain.Entities;

/// <summary>
/// Связь вызова и заданий
/// </summary>
public class ChallengeQuestBind : BaseEntity<Ulid>
{
    /// <summary>
    /// Идентификатор вызова
    /// </summary>
    public required Ulid ChallengeId { get; init; }

    /// <summary>
    /// Вызов
    /// </summary>
    public Challenge? Challenge { get; init; }

    /// <summary>
    /// Идентификатор задания
    /// </summary>
    public required Ulid QuestId { get; init; }

    /// <summary>
    /// Задание
    /// </summary>
    public Quest? Quest { get; init; }
}
