namespace TicketingAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Infrastructure.Persistence;

    public class SeatRepository : ISeatRepository
    {
        private readonly AppDbContext _context;

        public SeatRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetBySectorIdAsync(int sectorId)
        {
            return await _context.Seats.Where(s => s.SectorId== sectorId).OrderBy(s => s.RowIdentifier).ThenBy(s=>s.SeatNumber).ToListAsync();
        }
        public async Task<Seat?> GetByIdAsync(Guid seatId)
        {
            return await _context.Seats.FindAsync(seatId);
        }
        public async Task AddAsync(Seat seat)
        {
            await _context.Seats.AddAsync(seat);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Seat seat)
        {
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
        }
    }
}
