namespace TicketingAPI.Application.Interfaces
{
    using TicketingAPI.Domain.Entities;

    public interface IReservationRepository
    {
            Task<Reservation> GetByIdAsync(Guid id); 
            Task <Reservation> CreateAsync(Reservation reservation);
            Task<IEnumerable<Reservation>> GetByUserIdAsync(int userId);
            Task UpdateAsync(Reservation reservation);        
    }
}
