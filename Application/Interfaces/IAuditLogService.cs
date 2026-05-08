using TicketingAPI.Application.DTOs.AudiLog;

namespace TicketingAPI.Application.Interfaces
{
    public interface IAuditLogService
    {
        Task<IEnumerable<AuditLogResponseDto>> GetByEntityAsync(string entityType, string entityId);
        Task<IEnumerable<AuditLogResponseDto>> GetByUserIdAsync(int userId);
    }
}
