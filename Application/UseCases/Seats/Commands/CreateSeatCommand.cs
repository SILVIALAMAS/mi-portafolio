namespace TicketingAPI.Application.UseCases.Seats.Commands
{
    public class CreateSeatCommand
    { public int SectorId { get; set; }
      public string RowIdentifier { get; set; }= string.Empty;
      public int SeatNumber { get; set; }
    }
}
