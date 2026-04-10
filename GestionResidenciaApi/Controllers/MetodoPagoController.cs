using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPago _metodoPagoService ;

        public MetodoPagoController(IMetodoPago metodoPagoService)
        {
            _metodoPagoService = metodoPagoService;
        }

        // GET: api/MetodoPago
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.MetodoPago>>> GetMetodoPago()
        {
            var metodoPago = await _metodoPagoService.GetMetodoPagoAsync();
            return Ok(metodoPago);
        }

        // GET: api/MetodoPago por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.MetodoPago>> GetMetodoPago(int id)
        {
            var metodoPago = await _metodoPagoService.GetMetodoPagoByIdAsync(id);
            if (metodoPago is null) return NotFound();
            return Ok(metodoPago);
        }

        // POST: api/MetodoPago
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.MetodoPago>> CreateMetodoPago(GestionResidenciaApi.Models.MetodoPago metodoPago)
        {
            var createdMetodoPago = await _metodoPagoService.CreateMetodoPagoAsync(metodoPago);
            return CreatedAtAction(nameof(GetMetodoPago), new { id = createdMetodoPago.MetodoPagoId }, createdMetodoPago);
        }

        // PUT: api/MetodoPago/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.MetodoPago>> UpdateMetodoPago(int id, GestionResidenciaApi.Models.MetodoPago metodoPago)
        {
            var updatedMetodoPago = await _metodoPagoService.UpdateMetodoPagoAsync(id, metodoPago);
            if (updatedMetodoPago is null) return NotFound();
            return Ok(updatedMetodoPago);
        }

        // DELETE: api/MetodoPago/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.MetodoPago>> DeleteMetodoPago(int id)
        {
            var success = await _metodoPagoService.DeleteMetodoPagoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
