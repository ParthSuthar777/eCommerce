using Microsoft.AspNetCore.Mvc;
using UserService.Core.ServiceContracts;
using UserService.Core.DTO;
using Common.Helper;

namespace UserService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost(CommonApiRoute.Auth.Login)]
        public async Task<IActionResult> Login ([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Request body cannot be null");
            }
            var response = await _userService.Login(loginRequest);
            return Ok(response);
        }
        [HttpPost(CommonApiRoute.Auth.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Request body cannot be null");
            }
            var response = await _userService.Register(registerRequest);
            return Ok(response);
        }
    }
}
