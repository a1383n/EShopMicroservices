using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Framework.Api;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class BaseController : ControllerBase
{
    protected readonly IMapper _mapper;

    public BaseController(IMapper mapper)
    {
        _mapper = mapper;

        //TODO: It's good idea to inject the ILogger in base controller.
    }
}