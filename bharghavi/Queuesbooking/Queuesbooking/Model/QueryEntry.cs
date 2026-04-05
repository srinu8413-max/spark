using System.ComponentModel.DataAnnotations;

namespace Queuesbooking.Model
{
    public class QueryEntry
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.Now;

        public bool IsServed { get; set; } = false;
    }
}
