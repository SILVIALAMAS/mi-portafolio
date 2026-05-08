namespace TicketingAPI.Application.UseCases.Sectors.Commands
{
    public class UpdateSectorCommand
    { public int Id { get; set; }
      public string Name { get; set; } = string.Empty;
      public decimal Price { get; set; } 
      public int Capacity { get; set; }
    }
}
