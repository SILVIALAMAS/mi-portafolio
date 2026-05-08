namespace TicketingAPI.Application.DTOs.Event
{
    public class CreateEventDto
    {   public string Name { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public string Venue { get; set; } = string.Empty;
    }
}
