using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.UseCases;
using TicketingAPI.Domain.Entities;

namespace TicketingAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/auditlogs")]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogsController(IAuditLogService auditLogService)
        {
            _auditLogService  = auditLogService;
        }

        [HttpGet("entity/{entityType}/{entityId}")]
        public async Task<IActionResult> GetByEntity(string entityType , string entityId)
        {
            var result = await _auditLogService.GetByEntityAsync(entityType, entityId);
            
            return Ok(result);
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var result = await _auditLogService.GetByUserIdAsync(userId);
            return Ok(result);
        }

    }
}