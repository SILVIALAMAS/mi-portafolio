namespace TicketingAPI.Application.DTOs.Seat
{
    public class SeatResponseDto
    { public Guid Id { get; set; }
        public int SectorId { get; set; }
        public string RowIdentifier { get; set; } = string.Empty;
        public int SeatNumber { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
