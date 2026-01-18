using Domain.Enums;

namespace Domain.Entities;

/// <summary>
/// Связь пользователя и задания
/// </summary>
public class UserChallengeBind : BaseEntity<Ulid>
{
    /// <summary>
    /// Идентификатор задания
    /// </summary>
    public required Ulid ChallengeId {  get; init; }

    /// <summary>
    /// Задание
    /// </summary>
    public Challenge? Challenge {  get; init; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Ulid UserId { get; init; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; init; }

    /// <summary>
    /// Статус
    /// </summary>
    public required UserChallengeStatus Status { get; set; }

    /// <summary>
    /// Дата начала выполнения
    /// </summary>
    public DateTimeOffset? JoinedAt { get; init; }
}
