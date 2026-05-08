
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Infrastructure.Persistence;

namespace TicketingAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class EventosController : ControllerBase
        {
            private readonly AppDbContext _context;

            public EventosController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult GetEventos()
            {
            /*return Ok("Funciona");*/ return Ok(_context.Eventos.ToList());
            }

            [HttpPost]
            public IActionResult CrearEvento(Event evento)
            {
                _context.Eventos.Add(evento);
                _context.SaveChanges();
                return Ok(evento);
            }
        }
    }
