using API.Model.Providers.Phone.DTOs.Request;
using AutoMapper;
using Framework.Api;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Providers;

[ApiVersion("1.0")]
public class PhoneProviderController : BaseController
{
    public PhoneProviderController(IMapper mapper) : base(mapper)
    {
    }
    
    [HttpPost]
    public ApiResult Verification([FromBody] PhoneVerificationRequestDTO requestDto)
    {
        return ApiResult<String>.Successful("10");
    }
}