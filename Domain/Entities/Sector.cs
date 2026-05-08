namespace TicketingAPI.Domain.Entities
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public int EventId { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public Event Event { get; set; } = null!;

        public ICollection<Seat> Seats { get; set; }= new List<Seat>();
    }
}
