namespace TicketingAPI.Application.Interfaces
{
    using TicketingAPI.Domain.Entities;

    public interface ISectorRepository
    {
        Task<IEnumerable<Sector>> GetByEventIdAsync(int eventId);
        Task<Sector?> GetByIdAsync(int id);
        Task AddAsync (Sector sector);
        Task UpdateAsync(Sector sector);
    }
}
