namespace TicketingAPI.Application.UseCases.User.Handlers
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.User.Commands;
    using TicketingAPI.Application.DTOs.User;
    public class GetUsersHandler
    {
        private readonly IUserRepository _repo;

        public GetUsersHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<UserResponseDto>> Execute()
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            }).ToList();
        }
    }
}
