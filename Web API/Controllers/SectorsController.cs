
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.UseCases.Sectors.Commands;
using TicketingAPI.Domain.Entities;

namespace TicketingAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/events/{eventId}/sectors")]
    public class SectorsController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorsController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByEvent(int eventId)
        {
            var result = await _sectorService.GetByEventIdAsync(eventId);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int eventId, int id)
        {
            var result = await _sectorService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int eventId, [FromBody] CreateSectorCommand command)
        {
            command.EventId = eventId;
            var result = await _sectorService.CreateAsync(command);
            return CreatedAtAction(nameof(GetById), new { eventId, id = result.Id }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int eventId, int id, [FromBody] UpdateSectorCommand command)
        {
            command.Id = id;
            var result = await _sectorService.UpdateAsync(command);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
