using TicketingAPI.Application.DTOs.Seat;
using TicketingAPI.Application.UseCases.Seats.Commands;
using TicketingAPI.Application.UseCases.Seats.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.DTOs.Reservation;
namespace TicketingAPI.Application.UseCases.Seats.Handlers
{
    public class GetSeatByIdHandler
    {
        private readonly ISeatRepository _seatRepository;
        public GetSeatByIdHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public async Task<SeatResponseDto?> HandleAsync(GetSeatByIdQuery query)
        {
            var seat = await _seatRepository.GetByIdAsync(query.Id);
            if (seat == null) return null;
            return new SeatResponseDto
            {
                Id = seat.Id,
                SectorId = seat.SectorId,
                RowIdentifier = seat.RowIdentifier,
                SeatNumber = seat.SeatNumber,
                Status = seat.Status
            };
        }
    }
}