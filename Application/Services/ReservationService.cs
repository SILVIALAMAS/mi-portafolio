namespace TicketingAPI.Application.Services
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.Reservations.Handlers;
    using TicketingAPI.Application.UseCases.Reservations.Queries;
    using TicketingAPI.Application.UseCases.Reservations.Commands;
    using TicketingAPI.Application.DTOs.Reservation;

    public class ReservationService : IReservationService
    {
        private readonly GetReservationByIdHandler _getByIdHandler;
        private readonly GetReservationsByUserHandler _getByUserHandler;
        private readonly UpdateReservationHandler _updateHandler;
        
        public ReservationService(GetReservationByIdHandler getByIdHandler, GetReservationsByUserHandler getByUserHandler, UpdateReservationHandler updateHandler)
        {
            _getByIdHandler = getByIdHandler;
            _getByUserHandler = getByUserHandler;
            _updateHandler = updateHandler;
        }

        public async Task<ReservationResponseDto?> GetByIdAsync(Guid id)
          => await _getByIdHandler.HandleAsync(new GetReservationByIdQuery { Id = id });
        public async Task<IEnumerable<ReservationResponseDto>> GetByUserIdAsync(int userId)
              => await _getByUserHandler.HandleAsync(new GetReservationsByUserQuery { UserId = userId });
        public async Task<ReservationResponseDto?> UpdateAsync(UpdateReservationCommand command)
              => await _updateHandler.HandleAsync(command);

    }
}