using Microsoft.AspNetCore.Mvc;
using TicketingAPI.Infrastructure.Persistence;

namespace TicketingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuditLogsController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET todos los logs
        [HttpGet]
        public IActionResult GetLogs()
        {
            var logs = _context.Auditorias
                .OrderByDescending(l => l.CreatedAt)
                .ToList();

            return Ok(logs);
        }
    }
}