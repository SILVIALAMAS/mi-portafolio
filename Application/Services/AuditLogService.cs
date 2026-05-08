namespace TicketingAPI.Application.Services
{
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.UseCases.AuditLog.Handlers;
    using TicketingAPI.Application.UseCases.AuditLog.Queries;
    
    using TicketingAPI.Application.DTOs.AudiLog    ;
    using TicketingAPI.Application.DTOs.Reservation;

    public class AuditLogService : IAuditLogService
    {
        private readonly GetAuditLogsByEntityHandler _getByEntityHandler;
        private readonly GetAuditLogsByUserHandler _getByUserHandler;
        
        public AuditLogService(GetAuditLogsByEntityHandler getAuditLogsByEntityHandler, GetAuditLogsByUserHandler getByUserHandler)
        {
            _getByEntityHandler = getAuditLogsByEntityHandler;
            _getByUserHandler = getByUserHandler;
            
        }

        public async Task<IEnumerable<AuditLogResponseDto>> GetByEntityAsync(string entityType, string entityId)
          => await _getByEntityHandler.HandleAsync(new GetAuditLogsByEntityQuery { EntityType = entityType, EntityId = entityId });
        public async Task<IEnumerable<AuditLogResponseDto>> GetByUserIdAsync(int userId)
              => await _getByUserHandler.HandleAsync(new GetAuditLogsByUserQuery { UserId = userId   });
        
    }
}