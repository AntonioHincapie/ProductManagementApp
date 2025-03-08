using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using MyApp.Services;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            _userService.Register(user);
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(string username, string password)
        {
            var token = _userService.Authenticate(username, password);
            if (token == null) return Unauthorized();
            return Ok(new { token });
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUsers() => Ok(_userService.GetUsers());

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id) => Ok(_userService.GetUserById(id));

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            _userService.UpdateUser(user);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}