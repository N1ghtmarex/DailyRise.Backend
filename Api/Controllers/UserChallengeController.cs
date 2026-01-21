using Application.UserChallenges.Commands;
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
}
