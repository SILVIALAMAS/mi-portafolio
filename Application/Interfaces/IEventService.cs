using TicketingAPI.Application.DTOs.Event;
using TicketingAPI.Application.UseCases.Event.Commands;
namespace TicketingAPI.Application.Interfaces
{
    public interface IEventService
    {
        Task<IEnumerable<EventResponseDto>> GetAllAsync();
        Task<EventResponseDto?> GetByIdAsync(int id);
        Task<EventResponseDto> CreateAsync(CreateEventCommand command);
        Task<EventResponseDto> UpdateAsync(UpdateEventCommand command);
    }
}
