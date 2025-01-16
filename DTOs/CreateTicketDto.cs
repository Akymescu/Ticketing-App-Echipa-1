using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.DTOs
{
    public class CreateTicketDto
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Status { get; set; } // Asigură-te că există acest câmp în DTO


    }
}