using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPago _pagoService;

        public PagoController(IPago pagoService)
        {
            _pagoService = pagoService;
        }

        // GET: api/Pago
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Pago>>> GetPagos()
        {
            var pagos = await _pagoService.GetPagoAsync();
            return Ok(pagos);
        }

        // GET: api/Pago por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Pago>> GetPago(int id)
        {
            var pago = await _pagoService.GetPagoByIdAsync(id);
            if (pago is null) return NotFound();
            return Ok(pago);
        }

        // POST: api/Pago
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Pago>> CreatePago(GestionResidenciaApi.Models.Pago pago)
        {
            var createdPago = await _pagoService.CreatePagoAsync(pago);
            return CreatedAtAction(nameof(GetPago), new { id = createdPago.PagoId }, createdPago);
        }

        // PUT: api/Pago/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Pago>> UpdatePago(int id, GestionResidenciaApi.Models.Pago pago)
        {
            var updatedPago = await _pagoService.UpdatePagoAsync(id, pago);
            if (updatedPago is null) return NotFound();
            return Ok(updatedPago);
        }

        // DELETE: api/Pago/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Pago>> DeletePago(int id)
        {
            var success = await _pagoService.DeletePagoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
