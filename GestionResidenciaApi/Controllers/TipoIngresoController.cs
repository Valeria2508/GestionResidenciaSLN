using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIngresoController : ControllerBase
    {
        private readonly ITipoIngreso _tipoIngresoService;

        public TipoIngresoController(ITipoIngreso tipoIngresoService)
        {
            _tipoIngresoService = tipoIngresoService;
        }

        // GET: api/TipoIngreso
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.TipoIngreso>>> GetTipoIngresos()
        {
            var tipoIngresos = await _tipoIngresoService.GetTipoIngresoAsync();
            return Ok(tipoIngresos);
        }

        // GET: api/TipoIngreso por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoIngreso>> GetTipoIngreso(int id)
        {
            var tipoIngreso = await _tipoIngresoService.GetTipoIngresoByIdAsync(id);
            if (tipoIngreso is null) return NotFound();
            return Ok(tipoIngreso);
        }

        // POST: api/TipoIngreso
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoIngreso>> CreateTipoIngreso(GestionResidenciaApi.Models.TipoIngreso tipoIngreso)
        {
            var createdTipoIngreso = await _tipoIngresoService.CreateTipoIngresoAsync(tipoIngreso);
            return CreatedAtAction(nameof(GetTipoIngreso), new { id = createdTipoIngreso.TipoIngresoId }, createdTipoIngreso);
        }

        // PUT: api/TipoIngreso/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoIngreso>> UpdateTipoIngreso(int id, GestionResidenciaApi.Models.TipoIngreso tipoIngreso)
        {
            var updatedTipoIngreso = await _tipoIngresoService.UpdateTipoIngresoAsync(id, tipoIngreso);
            if (updatedTipoIngreso is null) return NotFound();
            return Ok(updatedTipoIngreso);
        }

        // DELETE: api/TipoIngreso/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoIngreso>> DeleteTipoIngreso(int id)
        {
            var success = await _tipoIngresoService.DeleteTipoIngresoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
