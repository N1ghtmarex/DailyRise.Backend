using Domain.Enums;

namespace Domain.Entities;

/// <summary>
/// Связь пользователя и испытания
/// </summary>
public class UserChallengeBind : BaseEntity<Ulid>
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Ulid UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Идентификатор испытания
    /// </summary>
    public required Ulid ChallengeId { get; set; }

    /// <summary>
    /// Испытание
    /// </summary>
    public Challenge? Challenge { get; set; }

    /// <summary>
    /// Дата вступления
    /// </summary>
    public required DateTimeOffset? JoinedAt { get; set; }

    /// <summary>
    /// Статус приглашения
    /// </summary>
    public required InviteStatus Status { get; set; }

    public ICollection<UserChallengeCheckIn>? CheckIns { get; set; }
}
