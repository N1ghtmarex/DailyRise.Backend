using Application.Challenges.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TgMiniAppAuth;

namespace Api.Controllers;

[ApiController]
[Route("api/challenge")]
[Authorize(AuthenticationSchemes = TgMiniAppAuthConstants.AuthenticationScheme)]
public class ChallengeController(ISender sender) : ControllerBase
{
    /// <summary>
    /// Добавление испытания
    /// </summary>
    /// <param name="command">Модель запроса</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    [HttpPost]
    public async Task<Ulid> CreateChallenge([FromQuery] CreateChallengeCommand command, CancellationToken cancellationToken)
    {
        return await sender.Send(command, cancellationToken);
    }
}
