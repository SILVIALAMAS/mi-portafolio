namespace TicketingAPI.Application.DTOs.Sector
{
    public class CreateSectorDto
    { public int Event { get; set; }
        public string Name { get; set; }= string.Empty;
        public decimal Price { get; set; }
        public int Capacity { get; set; }
    }
}
