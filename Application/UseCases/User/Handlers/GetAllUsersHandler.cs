using TicketingAPI.Application.Interfaces;

using TicketingAPI.Application.DTOs.User;
using TicketingAPI.Application.UseCases.User.Queries;
namespace TicketingAPI.Application.UseCases.User.Handlers
{
    public class GetAllUsersHandler
    {
        private readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UserResponseDto>> HandleAsync(GetAllUserQuery query)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserResponseDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            });
        }
    }
}
