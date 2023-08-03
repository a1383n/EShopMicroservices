using API.Model;
using AutoMapper;
using Entities.Models;
using Framework.Api;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.Enums;
using Services.Models;

namespace API.Controllers;

[ApiVersion("1.0")]
public class AuthController : BaseController
{
    private readonly IAuthService _authService;

    public AuthController(IMapper mapper, IAuthService authService) : base(mapper)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<ApiResult> Token(TokenRequest request)
    {
        var validator = new CredentialValidator();
        var result = await validator.ValidateAsync(request.Credential);
        
        if (!result.IsValid)
        {
            return ApiResult<Token>.UnprocessableEntity(new ValidationError(result.Errors));
        }

        var user = await _authService.AuthenticateWithPayload(
            (ProviderId)request.Credential.ProviderId!,
            (SignInMethod)request.Credential.SignInMethod!,
            request.Credential.GetPayload()
        );

        if (user.IsFailure)
            return ApiResult<AuthError>.Failed(user.Error);

        var token = await _authService.Login(user.Value, new Device
        {
            Type = request.DeviceDto.Type,
            Os = request.DeviceDto.Os,
            OsVersion = request.DeviceDto.OsVersion,
            Name = request.DeviceDto.Name,
            ClientVersion = request.DeviceDto.ClientVersion
        });

        return token.IsSuccess
            ? ApiResult<Token>.Successful(token.Value)
            : ApiResult<AuthError>.Failed(token.Error);
    }
}