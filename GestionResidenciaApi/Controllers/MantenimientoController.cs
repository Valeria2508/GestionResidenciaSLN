using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimiento _mantenimientoService;

        public MantenimientoController(IMantenimiento mantenimientoService)
        {
            _mantenimientoService = mantenimientoService;
        }

        // GET: api/Mantenimiento
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Mantenimiento>>> GetMantenimientos()
        {
            var mantenimientos = await _mantenimientoService.GetMantenimientoAsync();
            return Ok(mantenimientos);
        }

        // GET: api/Mantenimiento por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mantenimiento>> GetMantenimiento(int id)
        {
            var mantenimiento = await _mantenimientoService.GetMantenimientoByIdAsync(id);
            if (mantenimiento is null) return NotFound();
            return Ok(mantenimiento);
        }

        // POST: api/Mantenimiento
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mantenimiento>> CreateMantenimiento(GestionResidenciaApi.Models.Mantenimiento mantenimiento)
        {
            var createdMantenimiento = await _mantenimientoService.CreateMantenimientoAsync(mantenimiento);
            return CreatedAtAction(nameof(GetMantenimiento), new { id = createdMantenimiento.MantenimientoId }, createdMantenimiento);
        }

        // PUT: api/Mantenimiento/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mantenimiento>> UpdateMantenimiento(int id, GestionResidenciaApi.Models.Mantenimiento mantenimiento)
        {
            var updatedMantenimiento = await _mantenimientoService.UpdateMantenimientoAsync(id, mantenimiento);
            if (updatedMantenimiento is null) return NotFound();
            return Ok(updatedMantenimiento);
        }

        // DELETE: api/Mantenimiento/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mantenimiento>> DeleteMantenimiento(int id)
        {
            var success = await _mantenimientoService.DeleteMantenimientoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
