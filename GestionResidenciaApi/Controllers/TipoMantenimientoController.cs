using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMantenimientoController : ControllerBase
    {
        private readonly ITipoMantenimiento _tipoMantenimientoService;

        public TipoMantenimientoController(ITipoMantenimiento tipoMantenimientoService)
        {
            _tipoMantenimientoService = tipoMantenimientoService;
        }

        // GET: api/TipoMantenimiento
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.TipoMantenimiento>>> GetTipoMantenimientos()
        {
            var tipoMantenimientos = await _tipoMantenimientoService.GetTipoMantenimientoAsync();
            return Ok(tipoMantenimientos);
        }

        // GET: api/TipoMantenimiento por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoMantenimiento>> GetTipoMantenimiento(int id)
        {
            var tipoMantenimiento = await _tipoMantenimientoService.GetTipoMantenimientoByIdAsync(id);
            if (tipoMantenimiento is null) return NotFound();
            return Ok(tipoMantenimiento);
        }

        // POST: api/TipoMantenimiento
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoMantenimiento>> CreateTipoMantenimiento(GestionResidenciaApi.Models.TipoMantenimiento tipoMantenimiento)
        {
            var createdTipoMantenimiento = await _tipoMantenimientoService.CreateTipoMantenimientoAsync(tipoMantenimiento);
            return CreatedAtAction(nameof(GetTipoMantenimiento), new { id = createdTipoMantenimiento.TipoMantenimientoId }, createdTipoMantenimiento);
        }

        // PUT: api/TipoMantenimiento/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoMantenimiento>> UpdateTipoMantenimiento(int id, GestionResidenciaApi.Models.TipoMantenimiento tipoMantenimiento)
        {
            var updatedTipoMantenimiento = await _tipoMantenimientoService.UpdateTipoMantenimientoAsync(id, tipoMantenimiento);
            if (updatedTipoMantenimiento is null) return NotFound();
            return Ok(updatedTipoMantenimiento);
        }

        // DELETE: api/TipoMantenimiento/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoMantenimiento>> DeleteTipoMantenimiento(int id)
        {
            var success = await _tipoMantenimientoService.DeleteTipoMantenimientoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
