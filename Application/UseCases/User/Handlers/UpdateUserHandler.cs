using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.UseCases.User.Commands;
using TicketingAPI.Application.DTOs.User;
using TicketingAPI.Application.UseCases.User.Queries;
namespace TicketingAPI.Application.UseCases.User.Handlers
{
    public class UpdateUserHandler
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponseDto> HandleAsync(UpdateUserCommand command)
        {
            var user = await _userRepository.GetByIdAsync(command.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            user.Name = command.Name;
            user.Email = command.Email;
            await _userRepository.UpdateAsync(user);
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}