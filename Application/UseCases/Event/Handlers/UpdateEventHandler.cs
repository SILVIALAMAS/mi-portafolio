using TicketingAPI.Application.DTOs.Event;
using TicketingAPI.Application.UseCases.Event.Commands;
using TicketingAPI.Application.UseCases.Sectors.Handlers;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Event.Handlers
{
    public class UpdateEventHandler
    { private readonly IEventRepository _eventRepository;
        public UpdateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventResponseDto?> HandleAsync(UpdateEventCommand command)
        {
            var existingEvent = await _eventRepository.GetByIdWithSectorsAsync(command.Id);
            if (existingEvent == null)
            {
                throw new Exception("Evento no encontrado");
            }
            existingEvent.Name = command.Name;
            existingEvent.EventDate = command.EventDate;
            existingEvent.Venue = command.Venue;
            existingEvent.Status = command.Status;
            await _eventRepository.UpdateAsync(existingEvent);
            return new EventResponseDto
            {
                Id = existingEvent.Id,
                Name = existingEvent.Name,
                EventDate = existingEvent.EventDate,
                Venue = existingEvent.Venue,
                Status = existingEvent.Status
            };
        }
    }
}
