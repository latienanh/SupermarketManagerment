using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Application.DTOs.Auth;
using Supermarket.Application.IServices;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices _authServices;

        public AuthController(IAuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> Signup(SignUpDtos signUpDtos)
        {
            var result = await _authServices.SignUp(signUpDtos);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDtos loginDtos)
        {
            var result = await _authServices.LoginDtos(loginDtos);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            };
            return Ok(result);
        }

    }
}
