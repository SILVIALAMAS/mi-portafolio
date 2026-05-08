namespace TicketingAPI.Application.Interfaces
{
    using TicketingAPI.Domain.Entities;

    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync();
        Task<Event> GetByIdWithSectorsAsync(int id);
        Task AddAsync(Event newEvent);//Actualizado para aceptar un objeto Event completo
        Task UpdateAsync (Event existingEvent);//Actualizado para aceptar un objeto Event completo
    }
}
