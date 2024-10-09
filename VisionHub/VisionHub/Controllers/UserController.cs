using Microsoft.AspNetCore.Mvc;
using VisionHub.Models;
using VisionHub.Services;

namespace VisionHub.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // POST api/user/register
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] Users model)
        {
            try
            {
                _userService.AddUser(model.UserName, model.Email, model.Name, model.PasswordHash, model.Biography, model.BirthDate);
                return Ok(new { message = "User registered successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "An error occurred while registering the user." });
            }
        }

        // PUT api/user/update
        [HttpPut("update")]
        public IActionResult UpdateUser([FromBody] Users model)
        {
            try
            {
                _userService.UpdateUser(model.Id, model.UserName, model.Name, model.Email, model.PasswordHash, model.Biography, model.BirthDate);
                return Ok(new { message = "User updated successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.RemoveUser(id);
                return Ok(new { message = "User deleted successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            try
            {
                var users = _userService.GetUserInfo(id);
                if (users.Count == 0)
                {
                    return NotFound(new { message = "User not found!" });
                }
                return Ok(users[0]);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        // GET api/user/all
        [HttpGet("all")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
