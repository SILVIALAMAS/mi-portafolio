using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketingAPI.Domain.Entities;
using TicketingAPI.Infrastructure.Persistence;

namespace TicketingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ButacasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ButacasController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 GET todas las butacas
        [HttpGet]
        public IActionResult GetButacas()
        {
            var butacas = _context.Butacas
                .Include(b => b.Sector)
                .ToList();

            return Ok(butacas);
        }

        // 🔹 POST crear UNA butaca
        [HttpPost]
        public IActionResult CrearButaca(Butaca butaca)
        {
            var sectorExiste = _context.Sectores.Any(s => s.Id == butaca.SectorId);

            if (!sectorExiste)
            {
                return BadRequest("El sector no existe");
            }

            _context.Butacas.Add(butaca);
            _context.SaveChanges();

            return Ok(butaca);
        }

        // 🔥 POST crear MUCHAS butacas automáticamente
        [HttpPost("generar")]
        public IActionResult GenerarButacas(int sectorId)
        {
            var sector = _context.Sectores.FirstOrDefault(s => s.Id == sectorId);

            if (sector == null)
            {
                return BadRequest("Sector no encontrado");
            }

            var butacas = new List<Butaca>();

            for (int i = 1; i <= sector.Capacidad; i++)
            {
                butacas.Add(new Butaca
                {
                    NumeroButaca = i,
                    Estado = "Disponible",
                    SectorId = sectorId
                });
            }

            _context.Butacas.AddRange(butacas);
            _context.SaveChanges();

            return Ok(butacas);
        }
    }
}
