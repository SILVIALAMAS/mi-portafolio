using TicketingAPI.Application.DTOs.Sector;
using TicketingAPI.Application.UseCases.Sectors.Commands;
using TicketingAPI.Application.UseCases.Sectors.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Sectors.Handlers
{
    public class UpdateSectorHandler
    {
        private readonly ISectorRepository _sectorRepository;

        public UpdateSectorHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;

        }
        public async Task<SectorResponseDto> HandleAsync(UpdateSectorCommand command)
        {
            var sector = await _sectorRepository.GetByIdAsync(command.Id);
            if (sector == null)
            {
                throw new Exception("Sector not found");
            }
            sector.Name = command.Name;
            sector.Capacity = command.Capacity;
            sector.Price = command.Price;
            await _sectorRepository.UpdateAsync(sector);
            return new SectorResponseDto
            {
                Id = sector.Id,
                Name = sector.Name,
                Capacity = sector.Capacity,
                EventId = sector.EventId,
                Price = sector.Price,
                AvailableSeats = sector.Seats.Count(s=> s.Status == "Available")
            };
        }
    }
}