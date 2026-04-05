namespace quee.Models
{
    public class QueueEntry
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}