using TicketingAPI.Application.DTOs.Reservation;
using TicketingAPI.Application.UseCases.Reservations.Queries;
using TicketingAPI.Application.UseCases.Reservations.Commands;
namespace TicketingAPI.Application.Interfaces
{
    public interface IReservationService
    {   Task<ReservationResponseDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<ReservationResponseDto>> GetByUserIdAsync(int userId);
        Task<ReservationResponseDto?> UpdateAsync(UpdateReservationCommand command);
    }
}
