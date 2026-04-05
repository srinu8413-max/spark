using Microsoft.AspNetCore.Mvc;
using backend.Data;
using backend.Models;

namespace backend.Controllers
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

        [HttpPost("add")]
        public async Task<IActionResult> Add(string name)
        {
            int lastToken = _context.QueueItems
                .OrderByDescending(q => q.TokenNumber)
                .Select(q => q.TokenNumber)
                .FirstOrDefault();

            var item = new QueueItem
            {
                Name = name,
                TokenNumber = lastToken + 1,
                Status = "Waiting",
                CreatedAt = DateTime.Now
            };

            _context.QueueItems.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpGet]
        public IActionResult GetQueue()
        {
            var queue = _context.QueueItems
                .OrderBy(q => q.TokenNumber)
                .ToList();

            return Ok(queue);
        }

        [HttpPost("next")]
        public async Task<IActionResult> CallNext()
        {
            var next = _context.QueueItems
                .Where(q => q.Status == "Waiting")
                .OrderBy(q => q.TokenNumber)
                .FirstOrDefault();

            if (next == null)
                return NotFound("No one in queue");

            next.Status = "InProgress";
            await _context.SaveChangesAsync();

            return Ok(next);
        }

        [HttpPost("complete/{id}")]
        public async Task<IActionResult> Complete(int id)
        {
            var item = await _context.QueueItems.FindAsync(id);

            if (item == null)
                return NotFound("Item not found");

            item.Status = "Completed";
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.QueueItems.FindAsync(id);

            if (item == null)
                return NotFound("Item not found");

            _context.QueueItems.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Deleted successfully");
        }
    }
}