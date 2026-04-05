using Microsoft.EntityFrameworkCore;
using Queuesbooking.Model;
namespace Queuesbooking.Data
{
    public class AppDbcontext:DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
    {
        }

        public DbSet<User> user { get; set; }
        public DbSet<QueryEntry> queryEntry { get; set; }

    }
}
