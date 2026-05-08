namespace TicketingAPI.Application.UseCases.Sectors.Commands
{
    public class CreateSectorCommand
    { public int EventId { get; set; } 
      public string Name { get; set; } = string.Empty;
      public decimal Price { get; set; } 
      public int Capacity { get; set; }
    }
}
