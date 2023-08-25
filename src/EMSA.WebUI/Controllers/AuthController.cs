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
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
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
                var userToken = await _userService.GetUserTokenInfoAsync(user.Username); // TODO: load user
                // Generate token and return
                var token = _tokenService.GetToken(userToken, 0); // TODO: Get expiry minutes
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