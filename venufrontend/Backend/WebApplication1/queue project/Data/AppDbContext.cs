using Microsoft.EntityFrameworkCore;

namespace QueueManagementAPI   // ⚠️ Make sure this matches your project namespace
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Table
        public DbSet<QueueItem> QueueItems { get; set; }
    }
}