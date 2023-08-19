using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMSA.WebUI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("emsa/[controller]")]
    public class ApplicationBaseController : ControllerBase
    {
    }
}