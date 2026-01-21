using Domain.Enums;

namespace Domain.Entities;

/// <summary>
/// Отметка выполнения испытания пользователем
/// </summary>
public class UserChallengeCheckIn : BaseEntity<Ulid>
{
    /// <summary>
    /// Идентификатор испытания пользователя
    /// </summary>
    public required Ulid UserChallengeBindId { get; set; }

    /// <summary>
    /// Испытание пользователя
    /// </summary>
    public UserChallengeBind? UserChallengeBind { get; set; }

    /// <summary>
    /// Дата отметки
    /// </summary>
    public required DateTimeOffset CheckInDate { get; set; }

    /// <summary>
    /// Статус отметки
    /// </summary>
    public required CheckInStatus Status { get; set; }
}
