using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Queuesbooking.service;
using System.Security.Claims;

namespace Queuesbooking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "User")] // only users
    public class QueueController : ControllerBase
    {
        private readonly Query _queueService;

        public QueueController(Query queueService)
        {
            _queueService = queueService;
        }

        // ➕ Join Queue
        [HttpPost("join")]
        public async Task<IActionResult> JoinQueue()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            await _queueService.JoinQueue(userId);

            return Ok("Joined queue successfully");
        }

        // 📍 View Position
        [HttpGet("position")]
        public async Task<IActionResult> GetPosition()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var position = await _queueService.GetPosition(userId);

            if (position == null)
                return NotFound("You are not in queue");

            return Ok(new
            {
                position = position
            });
        }
    }
}