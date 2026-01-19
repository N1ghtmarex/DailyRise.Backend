using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TgMiniAppAuth;
using TgMiniAppAuth.AuthContext.User;

namespace Api;

[ApiController]
[Authorize(AuthenticationSchemes = TgMiniAppAuthConstants.AuthenticationScheme)]
[Route("/api/telegram")]
public class Controller : ControllerBase
{
    private readonly ITelegramUserAccessor _telegramUserAccessor;

    public Controller(ITelegramUserAccessor telegramUserAccessor)
    {
        _telegramUserAccessor = telegramUserAccessor;
    }

    [HttpGet("user")]
    public IActionResult GetUser()
    {
        return Ok(_telegramUserAccessor.User);
    }

    [AllowAnonymous]
    public IActionResult Get()
    {
        return Ok();
    }
}
