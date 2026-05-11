using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.UseCases.Seats.Commands;
using TicketingAPI.Domain.Entities;

namespace TicketingAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/events/{eventId}/sectors/{sectorId}/seats")]
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatsController(ISeatService seatService)
        {
            _seatService = seatService ;
        }

        [HttpGet]
        public async Task<IActionResult> GetBySector(int eventId, int sectorId)
        {
            var result = await _seatService.GetBySectorIdAsync(sectorId);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int eventId, int sectorId, Guid id)
        {
            var result = await _seatService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int eventId, int sectorId, [FromBody] CreateSeatCommand command)
        {

            command.SectorId = sectorId;
            var result = await _seatService.CreateAsync(command);
            return CreatedAtAction(nameof(GetById), new { eventId, sectorId, id = result.Id }, result);
        }  
        //Reserva una butaca por 5 minutos . Devuelve 409 si la butaca ya está reservada o vendida
        [HttpPost("{id}/reserve")]
        public async Task<IActionResult> Reserve(int eventId, int sectorId, Guid id, [FromBody] ReserveSeatCommand command)
        {
            command.SeatId = id;
            var (success, result, error) = await _seatService.ReserveAsync(command);
            if (!success) return Conflict(new {message = error});
            return Ok(result);
        }
    }
}

