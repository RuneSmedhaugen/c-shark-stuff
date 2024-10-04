/*
namespace RollRadar.Controllers

{
    using Microsoft.AspNetCore.Mvc;
    using RollRadar.Models;

    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthenticationService _authService;

        public UserController(UserService userService, AuthenticationService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Users user, string password)
        {
            _userService.Register(user, password);
            return Ok("User registered.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Users users)
        {
            var user = _authService.Login(users.Email, users.PasswordHash);
            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }
            return Ok(user);
        }
    }

}
*/
