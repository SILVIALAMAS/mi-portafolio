using TicketingAPI.Application.DTOs.User;
using TicketingAPI.Application.DTOs.Reservation;
using TicketingAPI.Application.UseCases.User.Commands;

namespace TicketingAPI.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<UserResponseDto?> GetByIdAsync(int id);
        Task<UserResponseDto> CreateAsync(CreateUserCommand command);
         Task<UserResponseDto> UpdateAsync(UpdateUserCommand command);
    }
}
