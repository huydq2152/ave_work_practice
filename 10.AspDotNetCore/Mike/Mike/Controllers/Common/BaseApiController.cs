using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mike.Controllers.Common
{
    [ApiController]
    [Route("[controller]")]
    public class BaseApiController : ControllerBase
    {
    }
}
