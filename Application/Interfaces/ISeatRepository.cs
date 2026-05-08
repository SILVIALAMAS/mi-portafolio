using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.Interfaces
{
    

    public interface ISeatRepository
    {
        Task<IEnumerable<Seat>> GetBySectorIdAsync(int sectorid);
        Task<Seat?> GetByIdAsync(Guid seatId);
        Task UpdateAsync(Seat seat);
        Task AddAsync(Seat seat);
    }
}
