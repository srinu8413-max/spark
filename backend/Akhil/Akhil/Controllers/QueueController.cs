using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class QueueController : ControllerBase
{
    private readonly AppDbContext _context;

    public QueueController(AppDbContext context)
    {
        _context = context;
    }

    // JOIN QUEUE
    [HttpPost("join")]
    public IActionResult JoinQueue(int userId)
    {
        var queue = new Queue
        {
            UserId = userId,
            JoinedAt = DateTime.Now
        };

        _context.Queues.Add(queue);
        _context.SaveChanges();

        return Ok(queue);
    }

    // ADMIN VIEW QUEUE
    [HttpGet]
    public IActionResult GetQueue()
    {
        var data = _context.Queues
            .Select(q => new {
                q.Id,
                q.JoinedAt,
                q.User.Name,
                q.User.Email
            }).ToList();

        return Ok(data);
    }
}