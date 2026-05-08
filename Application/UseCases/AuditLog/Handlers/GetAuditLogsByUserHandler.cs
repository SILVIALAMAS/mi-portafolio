using TicketingAPI.Application.Interfaces;
using TicketingAPI.Domain.Entities;

using TicketingAPI.Application.DTOs.AudiLog;
using TicketingAPI.Application.UseCases.AuditLog.Queries;
namespace TicketingAPI.Application.UseCases.AuditLog.Handlers
{
    public class GetAuditLogsByUserHandler
    {
        private readonly IAuditLogRepository _auditLogRepository;
        public GetAuditLogsByUserHandler(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }
        public async Task<IEnumerable<AuditLogResponseDto>> HandleAsync(GetAuditLogsByUserQuery query)
        {
            var logs = await _auditLogRepository.GetByUserIdAsync(query.UserId);
            return logs.Select(l => new AuditLogResponseDto
            {
                Id = l.Id,
                UserId = l.UserId,
                Action = l.Action,
                EntityType = l.EntityType,
                EntityId = l.EntityId,
                Details = l.Details,
                CreatedAt = l.CreatedAt
            });
        }
    }
}