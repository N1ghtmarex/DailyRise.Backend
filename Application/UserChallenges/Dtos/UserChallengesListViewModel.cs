using Domain.Enums;

namespace Application.UserChallenges.Dtos;

/// <summary>
/// Модель испытаний пользователя
/// </summary>
public class UserChallengesListViewModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public required Ulid Id { get; set; }

    /// <summary>
    /// Идентификатор испытания
    /// </summary>
    public required Ulid ChallengeId { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public required Ulid UserId { get; set; }

    /// <summary>
    /// Статус приглашения
    /// </summary>
    public required InviteStatus Status { get; set; }

    /// <summary>
    /// Дата вступления
    /// </summary>
    public required DateTimeOffset? JoinedAt { get; set; }
}
