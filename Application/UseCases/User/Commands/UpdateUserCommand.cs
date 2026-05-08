namespace TicketingAPI.Application.UseCases.User.Commands
{
    public class UpdateUserCommand
    { public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }=string.Empty;
    }
}
