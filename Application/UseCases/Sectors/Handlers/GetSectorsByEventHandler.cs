using TicketingAPI.Application.DTOs.Sector;
using TicketingAPI.Application.UseCases.Sectors.Commands;
using TicketingAPI.Application.UseCases.Sectors.Queries;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;
namespace TicketingAPI.Application.UseCases.Sectors.Handlers
{
    public class GetSectorsByEventHandler
    {
        private readonly ISectorRepository _sectorRepository;
        public GetSectorsByEventHandler(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }
        public async Task<IEnumerable<SectorResponseDto>> HandleAsync(GetSectorByEventQuery query)
        {
            var sectors = await _sectorRepository.GetByEventIdAsync(query.EventId);
            return sectors.Select(s => new SectorResponseDto
            {
                Id = s.Id,
                Name = s.Name,
                Capacity = s.Capacity,
                EventId = s.EventId,
                Price = s.Price,
                AvailableSeats = s.Seats.Count(seat => seat.Status == "Available")
            });
        }
    }
}