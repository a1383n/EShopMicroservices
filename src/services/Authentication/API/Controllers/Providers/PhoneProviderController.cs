using API.Model.Providers.Phone.DTOs.Request;
using AutoMapper;
using Common;
using Common.Model.Settings.Providers;
using Framework.Api;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Providers;

[Route("api/v{version:apiVersion}/auth/providers/phone/[action]")]
public class PhoneProviderController : BaseController
{
    private readonly PhoneAuthProviderSetting _setting;

    public PhoneProviderController(IMapper mapper, Settings setting) : base(mapper)
    {
        _setting = setting.AuthProviderSettings.PhoneAuthProviderSetting;
    }
    
    [HttpPost]
    public ApiResult Verification([FromBody] PhoneVerificationRequestDto requestDto)
    {
        return ApiResult<object>.Successful(this._setting);
    }
}