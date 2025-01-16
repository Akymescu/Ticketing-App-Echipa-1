namespace TicketingSystem.DTOs
{
    public class UpdateTicketDto
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}