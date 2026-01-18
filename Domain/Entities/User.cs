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
}
