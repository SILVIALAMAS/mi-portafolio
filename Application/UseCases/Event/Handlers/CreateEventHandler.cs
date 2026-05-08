using TicketingAPI.Application.DTOs.Event;
using TicketingAPI.Application.UseCases.Event.Commands;

using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;

namespace TicketingAPI.Application.UseCases.Event.Handlers
{
    public class CreateEventHandler
    { private readonly IEventRepository _eventRepository;
        public CreateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventResponseDto> HandleAsync(CreateEventCommand command)
        {
            var newEvent = new Domain.Entities.Event
            {
                Name = command.Name,
                EventDate = command.EventDate,
                Venue = command.Venue,
                Status = "Active" // Establecer un estado inicial
            };
            await _eventRepository.AddAsync(newEvent);
            return new EventResponseDto
            {
                Id = newEvent.Id,
                Name = newEvent.Name,
                EventDate = newEvent.EventDate,
                Venue = newEvent.Venue,
                Status = newEvent.Status
            };
        }
    }
}
