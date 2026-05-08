using TicketingAPI.Application.DTOs.Event;
using TicketingAPI.Application.UseCases.Event.Commands;
using TicketingAPI.Application.UseCases.Event.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Event.Handlers
{
    public class GetAllEventsHandler
    { private readonly IEventRepository _eventRepository;
        public GetAllEventsHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IEnumerable<EventResponseDto>> HandleAsync(GetAllEventsQuery query)
        {
            var events = await _eventRepository.GetAllAsync();
            return events.Select(e => new EventResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                EventDate = e.EventDate,
                Venue = e.Venue,
                Status = e.Status
            });
        }
    }
}
