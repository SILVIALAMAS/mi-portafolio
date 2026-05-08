namespace TicketingAPI.Application.DTOs.Reservation
{
    public class ReservationResponseDto
    { public Guid Id { get; set; }
        public int UserId { get; set; }
        public Guid SeatId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime ReservedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
