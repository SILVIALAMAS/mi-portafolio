namespace TicketingAPI.Application.DTOs.Seat
{
    public class UpdateSeatDto
    {   public string RowIdentifier { get; set; } = string.Empty;
        public int SeatNumer { get; set; } 
        public string Status { get; set; }=string.Empty;
    }
}
