namespace TicketingAPI.Application.Services
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.Sectors.Handlers;
    using TicketingAPI.Application.UseCases.Sectors.Queries;
    using TicketingAPI.Application.UseCases.Sectors.Commands;
    using TicketingAPI.Application.DTOs.Sector;

    public class SectorService : ISectorService
    {
        private readonly GetSectorsByEventHandler _getByEventHandler;
        private readonly GetSectorByIdHandler _getByIdHandler;
        private readonly CreateSectorHandler _createHandler;
        private readonly UpdateSectorHandler _updateHandler;
        public SectorService(GetSectorsByEventHandler getByEventHandler, GetSectorByIdHandler getByIdHandler, CreateSectorHandler createHandler, UpdateSectorHandler updateHandler)
        {
            _getByEventHandler = getByEventHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
        }

        public async Task<IEnumerable<SectorResponseDto>> GetByEventIdAsync(int eventId)
          => await _getByEventHandler.HandleAsync(new GetSectorByEventQuery { EventId = eventId });
        public async Task<SectorResponseDto?> GetByIdAsync(int id)
              => await _getByIdHandler.HandleAsync(new GetSectorByIdQuery());
        public async Task<SectorResponseDto> CreateAsync(CreateSectorCommand command)
              => await _createHandler.HandleAsync(command);
        public async Task<SectorResponseDto?> UpdateAsync(UpdateSectorCommand command)
              => await _updateHandler.HandleAsync(command);

    }
}