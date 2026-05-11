using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.UseCases.Reservations.Commands;
using TicketingAPI.Domain.Entities;

namespace TicketingAPI.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _reservationService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var result = await _reservationService.GetByUserIdAsync(userId);
            return Ok(result);
        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateReservationCommand command)
        {
            command.Id = id;
            var result = await _reservationService.UpdateAsync(command);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}