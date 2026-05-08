using TicketingAPI.Application.DTOs.Seat;
using TicketingAPI.Application.UseCases.Seats.Commands;
using TicketingAPI.Application.UseCases.Seats.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Seats.Handlers
{
    public class CreateSeatHandler
    {
        private readonly ISeatRepository _seatRepository;
        public CreateSeatHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public async Task<SeatResponseDto> HandleAsync(CreateSeatCommand command)
        {
            var seat = new Seat
            {
                SectorId = command.SectorId,
                RowIdentifier = command.RowIdentifier,
                SeatNumber = command.SeatNumber,
                Status = "Available",
                Version=0
            
            };
            await _seatRepository.AddAsync(seat);
            
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