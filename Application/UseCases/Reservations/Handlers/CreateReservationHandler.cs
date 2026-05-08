using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.UseCases.Reservations.Commands;
using TicketingAPI.Application.DTOs.Reservation;
using TicketingAPI.Application.UseCases.Reservations.Queries;
namespace TicketingAPI.Application.UseCases.Reservations.Handlers
{
    public class CreateReservationHandler
    {
        private readonly IReservationRepository _reservationRepository;
        public CreateReservationHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationResponseDto> Handle(CreateReservationCommand command)
        {
            var reservation = new Reservation
            {
                UserId = command.UserId,
                SeatId = command.SeatId,
                Status = "Pending",
                ReservedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(5)
            };
            await _reservationRepository.CreateAsync(reservation);
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