using EMSA.User.Models;
using EMSA.User.Services;
using EMSA.WebUI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EMSA.WebUI.Controllers
{
    public class AuthController : ApplicationBaseController
    {
        private readonly IUserService _userService;
        private readonly ITokenGeneratorService _tokenGeneratorService;

        public AuthController(IUserService userService, ITokenGeneratorService tokenGeneratorService)
        {
            _userService = userService;
            _tokenGeneratorService = tokenGeneratorService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLogin user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var valid = await _userService.IsValidUserAccountAsync(user);
            if (valid)
            {
                var userInfo = await _userService.GetUserInfoAsync(user.Username); // TODO: load user
                // Generate token and return
                var token = _tokenGeneratorService.GetToken(userInfo); // TODO: Get expiry minutes
                return Ok(new
                {
                    token,
                });
            }

            return BadRequest(new
            {
                statusCode = "invalid_user_account"
            });
        }
    }
}