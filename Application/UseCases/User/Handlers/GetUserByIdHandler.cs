using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Application.UseCases.User.Commands;
using TicketingAPI.Application.DTOs.User;
using TicketingAPI.Application.UseCases.User.Queries;
namespace TicketingAPI.Application.UseCases.User.Handlers
{
    public class GetUserByIdHandler
    {
        private readonly IUserRepository _userRepository;
        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserResponseDto?> HandleAsync(GetUserByIdQuery query)
        {
            var user = await _userRepository.GetByIdAsync(query.Id);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            return new UserResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
    }
}
