public class Queue
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime JoinedAt { get; set; }

    public User User { get; set; }
}