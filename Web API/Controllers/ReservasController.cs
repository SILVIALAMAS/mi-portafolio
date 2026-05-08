namespace TicketingAPI.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using TicketingAPI.Infrastructure;
    using TicketingAPI.Application.UseCases;
    using TicketingAPI.Domain.Entities;
    using TicketingAPI.Application.Interfaces;
    using TicketingAPI.Application.UseCases.Reservaciones.Commands;
    using TicketingAPI.Application.UseCases.Reservaciones.Handlers;
    using TicketingAPI.Application.DTOs.Reserva;

    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly CreateReservaHandler _createHandler;

        public ReservasController(CreateReservaHandler createHandler)
        {
            _createHandler = createHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationDto dto)
        {
            var command = new CreateReservasCommand
            {
                UserId = dto.UserId,
                ButacaId = dto.ButacaId
            };

            var result = await _createHandler.Handle(command);

            return Ok(result);
        }
    }
}