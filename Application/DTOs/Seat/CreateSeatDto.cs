namespace TicketingAPI.Application.DTOs.Seat
{
    public class CreateSeatDto
    { public int SectorId { get; set; }
        public string RowIdentifier { get; set; } = string.Empty;
      public int SeatNumber { get; set; }
    }
}
