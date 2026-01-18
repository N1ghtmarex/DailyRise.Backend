namespace Domain.Entities;

/// <summary>
/// Связь между пользователем и игровым профилем
/// </summary>
public class UserProfileBind : BaseEntity<Ulid>
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Ulid UserId { get; init; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; init; }

    /// <summary>
    /// Идентификатор игрового профиля
    /// </summary>
    public required Ulid ProfileId { get; init; }

    /// <summary>
    /// Игровой профиль
    /// </summary>
    public Profile? Profile { get; init; }
}
