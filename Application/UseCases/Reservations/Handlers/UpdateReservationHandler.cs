using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.UseCases.Reservations.Commands;
using TicketingAPI.Application.DTOs.Reservation;
using TicketingAPI.Application.UseCases.Reservations.Queries;
namespace TicketingAPI.Application.UseCases.Reservations.Handlers
{
    public class UpdateReservationHandler
    {
        private readonly IReservationRepository _reservationRepository;
        public UpdateReservationHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationResponseDto> HandleAsync(UpdateReservationCommand command)
        {
            var reservation = await _reservationRepository.GetByIdAsync(command.Id);
            if (reservation == null) return null;
            
            reservation.Status = command.Status;
            
            await _reservationRepository.UpdateAsync(reservation);
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