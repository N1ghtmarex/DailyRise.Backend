namespace Application.UserChallenges.Dtos;


/// <summary>
/// Модель отметки выполнения пользователя
/// </summary>
public class AddCheckInModel
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
