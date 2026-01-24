using Application.UserChallenges.Commands;
using Application.UserChallenges.Dtos;
using Application.UserChallenges.Queries;
using Application.Users.Dtos;
using Core.EntityFramework.Features.SearchPagination.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TgMiniAppAuth;

namespace Api.Controllers;

[ApiController]
[Route("api/user-challenge")]
[Authorize(AuthenticationSchemes = TgMiniAppAuthConstants.AuthenticationScheme)]
public class UserChallengeController(ISender sender)
{
    /// <summary>
    /// Приглашение пользователя в испытание
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("invite")]
    public async Task<Ulid> InviteUserToChallenge([FromQuery] InviteUserToChallengeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение списка испытаний пользователя
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet]
    public async Task<PagedResult<UserChallengesListViewModel>> GetUserChallenges([FromQuery] GetUserChallengeListQuery query,
        CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    /// <summary>
    /// Принятие испытания
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPut("accept/{ChallengeId}")]
    public async Task<Ulid> AcceptChallenge([FromQuery] AcceptChallengeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Отклонение испытания
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPut("reject/{ChallengeId}")]
    public async Task<Ulid> RejectChallenge([FromQuery] RejectChallengeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Отметка выполнения испытания
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost("check-in")]
    public async Task<Ulid> AddCheckIn([FromQuery] AddCheckInCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }

    /// <summary>
    /// Получение отметок выполнения испытания
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("check-in")]
    public async Task<List<UserChallengeCheckInListViewModel>> GetCheckIns([FromQuery] GetUserChallengeCheckInsQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }

    /// <summary>
    /// Получение списка пользователей испытания
    /// </summary>
    /// <param name="query">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpGet("{ChallengeId}/users")]
    public async Task<PagedResult<UserListViewModel>> GetChallengeUsers([FromQuery] GetChallengeUserListQuery query, CancellationToken cancellationToken)
    {
        return await sender.Send(query, cancellationToken);
    }
}
