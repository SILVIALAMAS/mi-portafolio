
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Tracing;
using TicketingAPI.Application.Interfaces;
using TicketingAPI.Application.UseCases.Event.Commands;
using TicketingAPI.Domain.Entities;

namespace TicketingAPI.WebAPI.Controllers
    {
    [ApiController]
    [Route("api/v1/events")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _eventService.GetAllAsync();
            return Ok(events);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _eventService.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventCommand command)
              {
            var result = await _eventService.CreateAsync(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
              }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] UpdateEventCommand command) 
        {
            command.Id = id;
            var result = await _eventService.UpdateAsync(command);
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
