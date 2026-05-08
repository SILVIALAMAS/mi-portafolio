namespace TicketingAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Infrastructure.Persistence;

    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AppDbContext _context;

        public AuditLogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(AuditLog log)
        {
            await _context.AuditLogs.AddAsync(log);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<AuditLog>> GetByEntityAsync(string entityType, string entityId)
        {
            return await _context.AuditLogs.Where(l => l.EntityType == entityType && l.EntityId == entityId).OrderByDescending(l => l.CreatedAt).ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _context.AuditLogs.Where(l => l.UserId == userId).OrderByDescending(l => l.CreatedAt).ToListAsync();
        }
    }
}
