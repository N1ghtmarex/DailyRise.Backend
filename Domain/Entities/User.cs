namespace Domain.Entities;

public class User : BaseEntity<Ulid>
{
    /// <summary>
    /// Идентификатор пользователя во внешней системе
    /// </summary>
    public required Guid ExternalUserId { get; set; }

    /// <summary>
    /// Имя пользователя
    /// </summary>
    public required string Username { get; set; }

    /// <summary>
    /// Ссылка на вызовы пользователя
    /// </summary>
    public ICollection<UserChallengeBind> UserChallenges { get; set; }
}
