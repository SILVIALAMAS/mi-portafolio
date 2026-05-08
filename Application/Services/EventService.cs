namespace TicketingAPI.Application.Services
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.Event.Handlers;
    using TicketingAPI.Application.UseCases.Event.Queries;
    using TicketingAPI.Application.DTOs.Event;
    using TicketingAPI.Application.UseCases.Event.Commands;
    public class EventService:IEventService
    {
        private readonly GetAllEventsHandler _getAllHandler;
        private readonly GetEventByIdHandler _getByIdHandler;
        private readonly CreateEventHandler _createHandler;
        private readonly UpdateEventHandler _updateHandler;
        public EventService(GetAllEventsHandler getAllHandler, GetEventByIdHandler getByIdHandler,CreateEventHandler createHandler,UpdateEventHandler updateHandler)
        {
            _getAllHandler = getAllHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
        }

        public async Task<IEnumerable<EventResponseDto>> GetAllAsync()
          => await _getAllHandler.HandleAsync(new GetAllEventsQuery());
        public async Task<EventResponseDto?> GetByIdAsync(int id)
              => await _getByIdHandler.HandleAsync(new GetEventByIdQuery());
        public async Task<EventResponseDto> CreateAsync(CreateEventCommand command)
              => await _createHandler.HandleAsync(command);
        public async Task<EventResponseDto?> UpdateAsync(UpdateEventCommand command)
              => await _updateHandler.HandleAsync(command);
    }
}
