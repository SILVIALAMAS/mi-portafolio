namespace TicketingAPI.Application.UseCases.Reservations.Commands
{
    public class UpdateReservationCommand
    {   public Guid Id { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
