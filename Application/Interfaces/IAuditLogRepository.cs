namespace TicketingAPI.Application.Interfaces
{
    using TicketingAPI.Domain.Entities;

    public interface IAuditLogRepository
    {
        Task CreateAsync(AuditLog log);
        Task <IEnumerable<AuditLog>> GetByUserIdAsync(int userId);
        Task <IEnumerable<AuditLog>>GetByEntityAsync(string entityType, string entityId);
    }
}
