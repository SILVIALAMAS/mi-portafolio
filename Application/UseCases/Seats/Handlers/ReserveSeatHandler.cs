using TicketingAPI.Application.DTOs.Seat;
using TicketingAPI.Application.UseCases.Seats.Commands;
using TicketingAPI.Application.UseCases.Seats.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.DTOs.Reservation;
namespace TicketingAPI.Application.UseCases.Seats.Handlers
{
    public class ReserveSeatHandler
    {
        private readonly ISeatRepository _seatRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IAuditLogRepository _auditLogRepository;
        public ReserveSeatHandler(ISeatRepository seatRepository, IReservationRepository reservationRepository, IAuditLogRepository auditLogRepository)
        {
            _seatRepository = seatRepository;
            _reservationRepository = reservationRepository;
            _auditLogRepository = auditLogRepository;
        }
        public async Task<(bool Success, ReserveSeatResponseDto? Result, string? Error)> HandleAsync(ReserveSeatCommand command)
        {
            await _auditLogRepository.CreateAsync(new AuditLog
            //Log del intento siempre

            {
                UserId = command.UserId,
                Action = "RESERVE_ATTEMPT",
                EntityType = "Seat",
                EntityId = command.SeatId.ToString(),
                Details = $"{{\"userId\": {command.UserId}, \"seatId\":\"{command.SeatId}\"}}"
            });
            var seat = await _seatRepository.GetByIdAsync(command.SeatId);
            if (seat == null)
                return (false, null, "Butaca no encontrada");
            if (seat.Status != "Available")
            {
                await _auditLogRepository.CreateAsync(new AuditLog
                {
                    UserId = command.UserId,
                    Action = "RESERVE_FAILED",
                    EntityType = "Seat",
                    EntityId = command.SeatId.ToString(),
                    Details = $"{{\"reason\": \"not_available\", \"status\":\"{seat.Status}\"}}"
                });
                return (false, null, "Butaca no disponible");
            }
            //cambiar estado
            seat.Status = "Reserved";
            seat.Version++; // Incrementar la versión para control de concurrencia
            await _seatRepository.UpdateAsync(seat);
            //crear reserva
            var reservation = new Reservation
            {
                UserId = command.UserId,
                SeatId = command.SeatId,
                Status = "Pending",
                ReservedAt = DateTime.UtcNow, //Hora actual en UTC
                ExpiresAt = DateTime.UtcNow.AddMinutes(5) // Expira en 5 minutos};
            };
            var created = await _reservationRepository.CreateAsync(reservation);
            //Log de reserva exitosa
            await _auditLogRepository.CreateAsync(new AuditLog
            {
                UserId = command.UserId,
                Action = "RESERVE_SUCCESS",
                EntityType = "Seat",
                EntityId = command.SeatId.ToString(),
                Details = $"{{\"reservationId\": {created.Id}, \"expiresAt\":\"{created.ExpiresAt:0}\"}}"
            });
                return (true,new ReserveSeatResponseDto
                {
                    ReservationId = created.Id,
                    SeatId = command.SeatId,
                    SeatStatus = "Reserved",
                    ExpiresAt = reservation.ExpiresAt,
                    Message = "Butaca reservada. Completa tu compra antes de 5 minutos"

                }, null);
    } } }