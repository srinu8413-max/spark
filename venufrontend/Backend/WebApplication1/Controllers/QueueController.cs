using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueueSystemAPI.Data;
using QueueSystemAPI.Models;

namespace QueueSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QueueController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QueueController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ POST: Add Queue (Swagger input)
        [HttpPost]
        public async Task<IActionResult> AddQueue([FromBody] QueueItem item)
        {
            if (item == null)
                return BadRequest("Invalid data");

            item.CreatedTime = DateTime.Now;

            _context.Queue.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        // ✅ GET: Check Queue
        [HttpGet]
        public async Task<IActionResult> GetQueue()
        {
            var data = await _context.Queue
                .OrderBy(q => q.CreatedTime) // FIFO
                .ToListAsync();

            return Ok(data);
        }
    }
}