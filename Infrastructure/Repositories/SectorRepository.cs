namespace TicketingAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Infrastructure.Persistence;

    public class SectorRepository : ISectorRepository
    {
        private readonly AppDbContext _context;

        public SectorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sector>> GetByEventIdAsync(int eventId)
        {
            return await _context.Sectors.Include(s => s.Seats).Where(s => s.EventId == eventId).ToListAsync();
        }
        public async Task<Sector?> GetByIdAsync(int id)
        {
            return await _context.Sectors.Include(s => s.Seats).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task AddAsync(Sector newSector)
        {
            await _context.Sectors.AddAsync(newSector);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Sector sector)
        {
            _context.Sectors.Update(sector);
            await _context.SaveChangesAsync();
        }
    }
}
