using Microsoft.EntityFrameworkCore;
using quee.Models;

namespace quee.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<QueueEntry> QueueEntries { get; set; }
    }
}