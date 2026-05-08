namespace TicketingAPI.Application.UseCases.User.Handlers
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.User.Commands;
    using TicketingAPI.Application.DTOs.User;
    using TicketingAPI.Application.UseCases.User.Queries;
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task <UserResponseDto> HandleAsync(CreateUserCommand command)
        {
            var user = new User
            {
                Name = command.Name,
                Email = command.Email,
                PasswordHash = command.Password // después podrías hashearlo
            };

            await _userRepository.AddAsync(user);
            return new UserResponseDto 
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }
}}
