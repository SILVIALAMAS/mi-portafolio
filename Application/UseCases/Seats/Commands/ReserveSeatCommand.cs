namespace TicketingAPI.Application.UseCases.Seats.Commands
{
    public class ReserveSeatCommand
    { public Guid SeatId { get; set; }
      public int UserId { get; set; }
    }
}
