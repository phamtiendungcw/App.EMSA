using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMSA.WebUI.Controllers
{
    public class PingController : ApplicationBaseController
    {
        [Route("ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("ping");
        }

        [Route("ping-anonymous")]
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PingAnonymous()
        {
            return Ok("ping anonymous");
        }
    }
}