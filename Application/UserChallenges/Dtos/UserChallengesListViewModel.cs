using Application.Challenges.Dtos;
using Domain.Entities;
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
    /// Испытание
    /// </summary>
    public ChallengeViewModel? Challenge { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Статус приглашения
    /// </summary>
    public required InviteStatus Status { get; set; }

    /// <summary>
    /// Дата вступления
    /// </summary>
    public required DateTimeOffset? JoinedAt { get; set; }
}
