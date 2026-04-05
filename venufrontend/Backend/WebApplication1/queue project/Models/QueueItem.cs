public class QueueItem
{
    public int Id { get; set; }
    public int TokenNumber { get; set; }
    public string CustomerName { get; set; }
    public string Stage { get; set; }  // Waiting, Processing, Completed
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}