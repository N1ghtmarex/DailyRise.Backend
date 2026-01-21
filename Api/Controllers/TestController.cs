using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TgMiniAppAuth;
using TgMiniAppAuth.AuthContext.User;

namespace Api.Controllers;

[ApiController]
[Authorize(AuthenticationSchemes = TgMiniAppAuthConstants.AuthenticationScheme)]
[Route("/api/telegram")]
public class TestController : ControllerBase
{
    private readonly ITelegramUserAccessor _telegramUserAccessor;

    public TestController(ITelegramUserAccessor telegramUserAccessor)
    {
        _telegramUserAccessor = telegramUserAccessor;
    }

    [HttpGet("user")]
    public IActionResult GetUser()
    {
        return Ok(_telegramUserAccessor.User);
    }

    [AllowAnonymous]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
