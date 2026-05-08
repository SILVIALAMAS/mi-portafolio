namespace TicketingAPI.Application.UseCases.AuditLog.Queries
{
    public class GetAuditLogsByEntityQuery
    {
        public string EntityType { get; set; } = string.Empty;
        public string EntityId { get; set; } = string.Empty;
    }
}
