namespace TicketingAPI.Application.Services
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.User.Handlers;
    using TicketingAPI.Application.UseCases.User.Queries;
    using TicketingAPI.Application.UseCases.User.Commands;
    using TicketingAPI.Application.DTOs.User;
    using TicketingAPI.Application.DTOs.Reservation;

    public class UserService : IUserService
    {
        private readonly GetAllUsersHandler _getAllHandler;
        private readonly GetUserByIdHandler _getByIdHandler;
        private readonly CreateUserHandler _createHandler;
        private readonly UpdateUserHandler _updateHandler;
        public UserService(GetAllUsersHandler getAllHandler, GetUserByIdHandler getByIdHandler, CreateUserHandler createHandler, UpdateUserHandler updateUserHandler)
        {
            _getAllHandler = getAllHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateUserHandler;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
          => await _getAllHandler.HandleAsync(new GetAllUserQuery());
        public async Task<UserResponseDto?> GetByIdAsync(int id)
              => await _getByIdHandler.HandleAsync(new GetUserByIdQuery { Id = id });
        public async Task<UserResponseDto> CreateAsync(CreateUserCommand command)
              => await _createHandler.HandleAsync(command);
        public async Task<UserResponseDto> UpdateAsync(UpdateUserCommand command)
              => await _updateHandler.HandleAsync(command);

    }
}
