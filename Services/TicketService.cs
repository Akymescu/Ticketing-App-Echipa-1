using Microsoft.EntityFrameworkCore;
using TicketingSystem.Data;
using TicketingSystem.DTOs;
using TicketingSystem.Entities;

namespace TicketingSystem.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketingDbContext _context;

        public TicketService(TicketingDbContext context)
        {
            _context = context;
        }

        public async Task<TicketDto> CreateTicket(CreateTicketDto createTicketDto)
        {
            // Validare: verificăm existența utilizatorului
            var userExists = await _context.Users.AnyAsync(u => u.Id == createTicketDto.UserId);
            if (!userExists)
            {
                throw new Exception("Utilizatorul specificat nu există.");
            }
            
            // Validare: verificăm existența categoriei
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == createTicketDto.CategoryId);
            if (!categoryExists)
            {
                throw new Exception("Categoria specificată nu există.");
            }

            //Crearea unui nou ticket
            var ticket = new Ticket
            {
                Title = createTicketDto.Title,
                Description = createTicketDto.Description,
                UserId = createTicketDto.UserId,
                CategoryId = createTicketDto.CategoryId,
                Status = createTicketDto.Status ?? "Open",  // Asigură-te că atribui un status
                CreatedAt = DateTime.UtcNow // Utilizează DateTime.UtcNow pentru data și ora curente

            };

            // Adăugare în baza de date
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            // Returnează DTO-ul rezultat
            return new TicketDto(ticket)
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                UserId = ticket.UserId,
                CategoryId = ticket.CategoryId
            };
        }

        public async Task<List<TicketDto>> GetTickets()
        {
            return await _context.Tickets
                .Include(t => t.User)
                .Include(t => t.Category)
                .Include(t => t.Comments)
                .ThenInclude(c => c.User)
                .Select(t => new TicketDto(t))
                .ToListAsync();
        }

        public async Task<TicketDto> GetTicket(int id)
        {
            var ticket = await _context.Tickets
                .Include(t => t.User)
                .Include(t => t.Category)
                .Include(t => t.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }

            return new TicketDto(ticket);
        }

        public async Task<TicketDto> UpdateTicket(int id, UpdateTicketDto updateTicketDto)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }

            ticket.CategoryId = updateTicketDto.CategoryId;
            ticket.Title = updateTicketDto.Title;
            ticket.Description = updateTicketDto.Description;
            ticket.Status = updateTicketDto.Status;

            await _context.SaveChangesAsync();

            return new TicketDto(ticket);
        }

        public async Task DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                throw new KeyNotFoundException($"Ticket with ID {id} not found.");
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }
}