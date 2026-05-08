namespace TicketingAPI.Application.DTOs.Sector
{
    public class SectorResponseDto
    { public int Id { get; set; }
        public int EventId { get; set; }
        public string Name { get; set; }= string.Empty;
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public int AvailableSeats { get; set; }
    }
}
