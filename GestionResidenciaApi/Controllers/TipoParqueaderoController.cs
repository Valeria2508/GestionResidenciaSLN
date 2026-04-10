using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoParqueaderoController : ControllerBase
    {
        private readonly ITipoParqueadero _tipoParqueaderoService;

        public TipoParqueaderoController(ITipoParqueadero tipoParqueaderoService)
        {
            _tipoParqueaderoService = tipoParqueaderoService;
        }

        // GET: api/TipoParqueadero
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.TipoParqueadero>>> GetTipoParqueadero()
        {
            var tipoParqueaderos = await _tipoParqueaderoService.GetTipoParqueaderoAsync();
            return Ok(tipoParqueaderos);
        }

        // GET: api/TipoParqueadero por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoParqueadero>> GetTipoParqueadero(int id)
        {
            var tipoParqueadero = await _tipoParqueaderoService.GetTipoParqueaderoByIdAsync(id);
            if (tipoParqueadero is null) return NotFound();
            return Ok(tipoParqueadero);
        }

        // POST: api/TipoParqueadero
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoParqueadero>> CreateTipoParqueadero(GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero)
        {
            var createdTipoParqueadero = await _tipoParqueaderoService.CreateTipoParqueaderoAsync(tipoParqueadero);
            return CreatedAtAction(nameof(GetTipoParqueadero), new { id = createdTipoParqueadero.TipoParqueaderoId }, createdTipoParqueadero);
        }

        // PUT: api/TipoParqueadero/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoParqueadero>> UpdateTipoParqueadero(int id, GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero)
        {
            var updatedTipoParqueadero = await _tipoParqueaderoService.UpdateTipoParqueaderoAsync(id, tipoParqueadero);
            if (updatedTipoParqueadero is null) return NotFound();
            return Ok(updatedTipoParqueadero);
        }

        // DELETE: api/TipoParqueadero/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoParqueadero>> DeleteTipoParqueadero(int id)
        {
            var success = await _tipoParqueaderoService.DeleteTipoParqueaderoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
