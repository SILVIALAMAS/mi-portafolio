using TicketingAPI.Application.DTOs.Sector;
using TicketingAPI.Application.UseCases.Sectors.Commands;
using TicketingAPI.Application.UseCases.Sectors.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Sectors.Handlers
{
    public class GetSectorByIdHandler
    {
        private readonly ISectorRepository _sectorRepository;
        public GetSectorByIdHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }
        public async Task<SectorResponseDto?> HandleAsync(GetSectorByIdQuery query)
        {
            var sector = await _sectorRepository.GetByIdAsync(query.Id);
            if (sector == null)
            {
                throw new Exception("Sector not found");
            }
            return new SectorResponseDto
            {
                Id = sector.Id,
                Name = sector.Name,
                Capacity = sector.Capacity,
                EventId = sector.EventId,
                Price = sector.Price,
                AvailableSeats = sector.Seats.Count(s => s.Status == "Available")
            };
        }
    }
}