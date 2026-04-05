using Microsoft.EntityFrameworkCore;
using QueueSystemAPI.Models;

namespace QueueSystemAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<QueueItem> Queue { get; set; }
    }
}