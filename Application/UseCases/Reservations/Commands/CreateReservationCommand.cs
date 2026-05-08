namespace TicketingAPI.Application.UseCases.Reservations.Commands
{
    public class CreateReservationCommand
    { public int UserId { get; set; }
      public Guid SeatId { get; set; }
    }
}
