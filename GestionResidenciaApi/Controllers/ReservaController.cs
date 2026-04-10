using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReserva _reservaService;

        public ReservaController(IReserva reservaService)
        {
            _reservaService = reservaService;
        }

        // GET: api/Reservas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Reserva>>> GetReservas()
        {
            var reservas = await _reservaService.GetReservaAsync();
            return Ok(reservas);
        }

        // GET: api/Reservas por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Reserva>> GetReserva(int id)
        {
            var reserva = await _reservaService.GetReservaByIdAsync(id);
            if (reserva is null) return NotFound();
            return Ok(reserva);
        }

        // POST: api/Reservas
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Reserva>> CreateReserva(GestionResidenciaApi.Models.Reserva reserva)
        {
            var createdReserva = await _reservaService.CreateReservaAsync(reserva);
            return CreatedAtAction(nameof(GetReserva), new { id = createdReserva.ReservaId }, createdReserva    );
        }

        // PUT: api/Apartamentos/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Reserva>> UpdateReserva(int id, GestionResidenciaApi.Models.Reserva reserva)
        {
            var updatedReserva = await _reservaService.UpdateReservaAsync(id, reserva);
            if (updatedReserva is null) return NotFound();
            return Ok(updatedReserva);
        }

        // DELETE: api/Reservas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Reserva>> DeleteReserva(int id)
        {
            var success = await _reservaService.DeleteReservaAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
