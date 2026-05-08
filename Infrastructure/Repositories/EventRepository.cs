namespace TicketingAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Infrastructure.Persistence;

    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events.Include(e=>e.Sectors).ThenInclude(s=>s.Seats).ToListAsync();
        }
        public async Task<Event?> GetByIdWithSectorsAsync(int id)
        {
            return await _context.Events.Include(e => e.Sectors).ThenInclude(s => s.Seats).FirstOrDefaultAsync(e=>e.Id ==id);
        }
        public async Task AddAsync(Event newEvent)
        {
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Event existingEvent)
        {
            _context.Events.Update(existingEvent);
            await _context.SaveChangesAsync();
        }
    }
}
