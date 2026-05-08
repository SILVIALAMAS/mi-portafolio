using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Infrastructure.Persistence;

namespace TicketingAPI.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class SectoresController : ControllerBase
        {
            private readonly AppDbContext _context;

            public SectoresController(AppDbContext context)
            {
                _context = context;
            }

            // 🔹 GET todos los sectores
            [HttpGet]
            public IActionResult GetSectores()
            {
                var sectores = _context.Sectores
                    .Include(s => s.Evento)
                    .ToList();

                return Ok(sectores);
            }

            // 🔹 POST crear sector
            [HttpPost]
            public IActionResult CrearSector(Sector sector)
            {
                var eventoExiste = _context.Eventos.Any(e => e.Id == sector.EventoId);

                if (!eventoExiste)
                {
                    return BadRequest("El evento no existe");
                }

                _context.Sectores.Add(sector);
                _context.SaveChanges();

                return Ok(sector);
            }
        }
    }
