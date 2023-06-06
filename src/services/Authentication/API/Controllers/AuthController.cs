using API.Model;
using Core.Enums;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace API.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Token(TokenRequest request)
    {
        var validator = new CredentialValidator();
        var result = validator.Validate(request.Credential);

        if (result.IsValid)
        {
            var user = await _authService.LoginWithPayload(
                (ProviderId)request.Credential.ProviderId!,
                (SignInMethod)request.Credential.SignInMethod!,
                request.Credential.GetPayload());

            return Ok((object?)user.GetResult().ToJson() ?? user.GetError());
        }
        else
        {
            return UnprocessableEntity(result.ToDictionary());
        }
    }
}