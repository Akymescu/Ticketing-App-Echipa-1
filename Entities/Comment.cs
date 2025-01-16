namespace TicketingSystem.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Ticket Ticket { get; set; }
        public User User { get; set; }
    }
}