using TicketingAPI.Application.DTOs.Seat;
using TicketingAPI.Application.DTOs.Reservation;
using TicketingAPI.Application.UseCases.Seats.Commands;
namespace TicketingAPI.Application.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatResponseDto>> GetBySectorIdAsync(int sectorId);
        Task<SeatResponseDto?> GetByIdAsync(Guid id);
        Task<SeatResponseDto> CreateAsync(CreateSeatCommand command);
        Task<(bool Success, ReserveSeatResponseDto?Result, string? Error)>ReserveAsync(ReserveSeatCommand command);
    }
}
