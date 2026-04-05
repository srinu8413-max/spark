using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueueManagementAPI; // ✅ IMPORTANT (your DbContext namespace)

namespace queue_project.Controllers
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

        // ✅ Add Queue
        [HttpPost]
        public async Task<IActionResult> AddQueue([FromBody] QueueItem item)
        {
            item.Stage = "Waiting";
            item.CreatedTime = DateTime.Now;
            item.UpdatedTime = DateTime.Now;

            _context.QueueItems.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        // ✅ Get All Queue
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _context.QueueItems.ToListAsync();
            return Ok(data);
        }

        // ✅ Update Stage
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStage(int id, [FromBody] string stage)
        {
            var item = await _context.QueueItems.FindAsync(id);
            if (item == null) return NotFound();

            item.Stage = stage;
            item.UpdatedTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok(item);
        }

        // ✅ Get by Stage
        [HttpGet("stage/{stage}")]
        public async Task<IActionResult> GetByStage(string stage)
        {
            var data = await _context.QueueItems
                .Where(x => x.Stage == stage)
                .ToListAsync();

            return Ok(data);
        }
    }
}