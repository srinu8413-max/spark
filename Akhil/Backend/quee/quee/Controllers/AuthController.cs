using Microsoft.AspNetCore.Mvc;
using quee.Data;
using quee.Models;

namespace quee.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }
    }
}