using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Queuesbooking.Model;
using Queuesbooking.service;

namespace Queuesbooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Auth _authService;

        public AuthController(Auth authService)
        {
            _authService = authService;
        }

        // 🔓 LOGIN (no authorize here)
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login request)
        {
            var token = await _authService.LoginAsync(request);

            if (token == null)
                return Unauthorized("Invalid username or password");

            return Ok(new
            {
                token = token
            });
        }

        // 🔒 ONLY LOGGED-IN USERS
        [Authorize]
        [HttpGet("profile")]
        public IActionResult Profile()
        {
            var username = User.Identity?.Name;

            return Ok(new
            {
                message = "Authenticated user",
                user = username
            });
        }

        // 👤 ONLY USER ROLE
        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public IActionResult UserOnly()
        {
            return Ok("Welcome User 👤");
        }

        // 👑 ONLY ADMIN ROLE
        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Welcome Admin 👑");
        }
    }
}