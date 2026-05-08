using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.UseCases.Reservations.Commands;
using TicketingAPI.Application.DTOs.Reservation;
using TicketingAPI.Application.UseCases.Reservations.Queries;
namespace TicketingAPI.Application.UseCases.Reservations.Handlers
{
    public class GetReservationsByUserHandler
    { private readonly IReservationRepository _reservationRepository;
        public GetReservationsByUserHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<IEnumerable<ReservationResponseDto>> HandleAsync(GetReservationsByUserQuery query)
        {
            var reservations = await _reservationRepository.GetByUserIdAsync(query.UserId);
            return reservations.Select(r => new ReservationResponseDto
            {
                Id = r.Id,
                SeatId = r.SeatId,
                UserId = r.UserId,
                Status = r.Status,
                ReservedAt = r.ReservedAt,
                ExpiresAt = r.ExpiresAt
            });
        }
    }
}
