using TicketingSystem.Entities;

namespace TicketingSystem.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserFullName { get; set; }
        public string CategoryName { get; set; }
        public List<CommentDto> Comments { get; set; }

        public TicketDto(Ticket ticket)
        {
            Id = ticket.Id;
            UserId = ticket.UserId;
            CategoryId = ticket.CategoryId;
            Title = ticket.Title;
            Description = ticket.Description;
            Status = ticket.Status;
            CreatedAt = ticket.CreatedAt;
            UserFullName = ticket.User != null ? $"{ticket.User.FirstName} {ticket.User.LastName}" : "Unknown User";
            CategoryName = ticket.Category != null ? ticket.Category.Name : "Unknown Category";

            Comments = ticket.Comments.Select(c => new CommentDto
            {
                Id = c.Id,
                TicketId = c.TicketId,
                Text = c.Text,
                UserId = c.UserId,
                CreatedAt = c.CreatedAt,
                UserFullName = $"{c.User.FirstName} {c.User.LastName}"
            }).ToList();
        }
    }
}