using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoDetalleController : ControllerBase
    {
        private readonly IPagoDetalle _pagoDetalleService;

        public PagoDetalleController(IPagoDetalle pagoDetalleService)
        {
            _pagoDetalleService = pagoDetalleService;
        }

        // GET: api/PagoDetalle
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.PagoDetalle>>> GetPagoDetalles()
        {
            var pagoDetalles = await _pagoDetalleService.GetPagoDetallesAsync();
            return Ok(pagoDetalles);
        }

        // GET: api/PagoDetalle por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.PagoDetalle>> GetPagoDetalle(int id)
        {
            var pagoDetalle = await _pagoDetalleService.GetPagoDetalleByIdAsync(id);
            if (pagoDetalle is null) return NotFound();
            return Ok(pagoDetalle);
        }

        // POST: api/PagoDetalle
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.PagoDetalle>> CreatePagoDetalle(GestionResidenciaApi.Models.PagoDetalle pagoDetalle)
        {
            var createdPagoDetalle = await _pagoDetalleService.CreatePagoDetalleAsync(pagoDetalle);
            return CreatedAtAction(nameof(GetPagoDetalle), new { id = createdPagoDetalle.PagoDetalleId }, createdPagoDetalle);
        }

        // PUT: api/PagoDetalle/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.PagoDetalle>> UpdatePagoDetalle(int id, GestionResidenciaApi.Models.PagoDetalle pagoDetalle)
        {
            var updatedPagoDetalle = await _pagoDetalleService.UpdatePagoDetalleAsync(id, pagoDetalle);
            if (updatedPagoDetalle is null) return NotFound();
            return Ok(updatedPagoDetalle);
        }

        // DELETE: api/PagoDetalle/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.PagoDetalle>> DeletePagoDetalle(int id)
        {
            var success = await _pagoDetalleService.DeletePagoDetalleAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
