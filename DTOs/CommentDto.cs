namespace TicketingSystem.DTOs
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserFullName { get; set; }
    }
}