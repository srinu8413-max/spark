namespace backend.Models
{
    public class QueueItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TokenNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}