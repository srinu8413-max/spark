using Microsoft.AspNetCore.Mvc;
using quee.Data;
using quee.Models;

namespace quee.Controllers
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

        [HttpPost("join")]
        public IActionResult JoinQueue(int userId)
        {
            var entry = new QueueEntry
            {
                UserId = userId,
                JoinedAt = DateTime.Now
            };

            _context.QueueEntries.Add(entry);
            _context.SaveChanges();

            return Ok(entry);
        }

        [HttpGet]
        public IActionResult GetQueue()
        {
            var queue = _context.QueueEntries
                .OrderBy(q => q.JoinedAt)
                .ToList();

            return Ok(queue);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entry = _context.QueueEntries.Find(id);

            if (entry == null)
                return NotFound();

            _context.QueueEntries.Remove(entry);
            _context.SaveChanges();

            return Ok();
        }
    }
}