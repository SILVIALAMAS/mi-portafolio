using TicketingAPI.Application.DTOs.Sector;
using TicketingAPI.Application.UseCases.Sectors.Commands;
using TicketingAPI.Application.UseCases.Sectors.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Sectors.Handlers
{
    public class CreateSectorHandler
    {
        private readonly ISectorRepository _sectorRepository;
        
        public CreateSectorHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
            
        }
        public async Task<SectorResponseDto> HandleAsync(CreateSectorCommand command)
        {
            var sector = new Sector
            {
                Name = command.Name,
                Capacity = command.Capacity,
                EventId = command.EventId,
                Price = command.Price
            };
            await _sectorRepository.AddAsync(sector);
            return new SectorResponseDto
            {
                Id = sector.Id,
                Name = sector.Name,
                Capacity = sector.Capacity,
                EventId = sector.EventId,
                Price = sector.Price,
                AvailableSeats = 0
            };
        }
    }
}