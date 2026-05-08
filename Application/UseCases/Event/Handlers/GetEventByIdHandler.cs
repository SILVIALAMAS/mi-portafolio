using TicketingAPI.Application.DTOs.Event;
using TicketingAPI.Application.UseCases.Event.Commands;
using TicketingAPI.Application.UseCases.Event.Queries;

using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Event.Handlers
{
    public class GetEventByIdHandler
    {
        private readonly IEventRepository _eventRepository;
        public GetEventByIdHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<EventResponseDto?> HandleAsync(GetEventByIdQuery query)
        {
            var existingEvent = await _eventRepository.GetByIdWithSectorAsync(query.Id);
            if (existingEvent == null)
            {
                throw new Exception("Evento no encontrado");
            }
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
