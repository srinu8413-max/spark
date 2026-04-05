namespace QueueSystemAPI.Models
{
    public class QueueItem
    {
        public int Id { get; set; }
        public string TokenNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}