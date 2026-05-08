using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.UseCases.Reservations.Commands;
using TicketingAPI.Application.DTOs.Reservation;
using TicketingAPI.Application.UseCases.Reservations.Queries;
namespace TicketingAPI.Application.UseCases.Reservations.Handlers
{
    public class GetReservationByIdHandler
    { private readonly IReservationRepository _reservationRepository;
        public GetReservationByIdHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationResponseDto> HandleAsync(GetReservationByIdQuery query)
        {
            var reservation = await _reservationRepository.GetByIdAsync(query.Id);
            if (reservation == null) return null;
            return new ReservationResponseDto
            {
                Id = reservation.Id,
                SeatId = reservation.SeatId,
                UserId = reservation.UserId,
                Status = reservation.Status,
                ReservedAt = reservation.ReservedAt,
                ExpiresAt = reservation.ExpiresAt
            };
        }
    }
}
