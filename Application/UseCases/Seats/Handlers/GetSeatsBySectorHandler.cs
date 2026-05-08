using TicketingAPI.Application.DTOs.Seat;
using TicketingAPI.Application.UseCases.Seats.Commands;
using TicketingAPI.Application.UseCases.Seats.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.DTOs.Reservation;
namespace TicketingAPI.Application.UseCases.Seats.Handlers
{
    public class GetSeatsBySectorHandler
    { private readonly ISeatRepository _seatRepository;
        public GetSeatsBySectorHandler(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
        public async Task<IEnumerable<SeatResponseDto>> HandleAsync(GetSeatsBySectorQuery query)
        {
            var seats = await _seatRepository.GetBySectorIdAsync(query.SectorId);
            return seats.Select(s => new SeatResponseDto
            {
                Id = s.Id,
                SectorId = s.SectorId,
                RowIdentifier = s.RowIdentifier,
                SeatNumber = s.SeatNumber,
                Status = s.Status
            });
        }
    }
}
