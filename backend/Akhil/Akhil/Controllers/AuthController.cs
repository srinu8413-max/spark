using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] User user)
    {
        if (user == null)
        {
            return BadRequest("Invalid data");
        }

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(user);
    }
}