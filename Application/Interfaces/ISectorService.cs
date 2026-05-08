using TicketingAPI.Application.DTOs.Sector;
using TicketingAPI.Application.UseCases.Sectors.Commands;
namespace TicketingAPI.Application.Interfaces
{
    public interface ISectorService
    { Task<IEnumerable<SectorResponseDto>> GetByEventIdAsync(int eventId);
        Task<SectorResponseDto?> GetByIdAsync(int id);
        Task<SectorResponseDto> CreateAsync(CreateSectorCommand command);
        Task<SectorResponseDto> UpdateAsync(UpdateSectorCommand command);
    }
}
