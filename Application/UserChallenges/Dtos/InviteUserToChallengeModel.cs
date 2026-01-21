namespace Application.UserChallenges.Dtos;

/// <summary>
/// Модель приглашения пользователя в испытание
/// </summary>
public class InviteUserToChallengeModel
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Ulid UserId { get; set; }

    /// <summary>
    /// Идентификатор испытания
    /// </summary>
    public required Ulid ChallengeId { get; set; }
}
