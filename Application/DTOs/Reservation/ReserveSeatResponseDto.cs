namespace TicketingAPI.Application.DTOs.Reservation
{
    public class ReserveSeatResponseDto
    { public Guid ReservationId { get; set; }
        public Guid SeatId { get; set; }
        public string SeatStatus { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
