using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Services;
using MyApp.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var token = _userService.Authenticate(user.Username, user.Password);
            if (token == null) return Unauthorized();

            return Ok(new { token });
        }

        [Authorize]
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            _userService.Logout();
            Response.Cookies.Delete("token");

            return Ok(new { message = "User logged out successfully" });
        }
    }
}