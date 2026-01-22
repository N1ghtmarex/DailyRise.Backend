using Application.UserChallenges.Commands;
using Application.UserChallenges.Dtos;
using Application.UserChallenges.Queries;
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
        return await sender.Send(command);
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
        return await sender.Send(query);
    }

    /// <summary>
    /// Принятие испытания
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPut("{ChallengeId}")]
    public async Task<Ulid> AcceptChallenge([FromQuery] AcceptChallengeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command);
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
        return await sender.Send(command);
    }
}
