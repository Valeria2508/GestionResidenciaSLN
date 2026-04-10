using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoParqueaderoController : ControllerBase
    {
        private readonly IEstadoParqueadero _estadoParqueaderoService;

        public EstadoParqueaderoController(IEstadoParqueadero estadoParqueaderoService)
        {
            _estadoParqueaderoService = estadoParqueaderoService;
        }

        // GET: api/EstadoParqueadero
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.EstadoParqueadero>>> GetEstadoParqueadero()
        {
            var estadoParqueaderos = await _estadoParqueaderoService.GetEstadosParqueaderoAsync();
            return Ok(estadoParqueaderos);
        }

        // GET: api/EstadoParqueadero por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoParqueadero>> GetEstadoParqueadero(int id)
        {
            var estadoParqueadero = await _estadoParqueaderoService.GetEstadoParqueaderoByIdAsync(id);
            if (estadoParqueadero is null) return NotFound();
            return Ok(estadoParqueadero);
        }

        // POST: api/EstadoParqueadero
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoParqueadero>> CreateEstadoParqueadero(GestionResidenciaApi.Models.EstadoParqueadero estadoParqueadero)
        {
            var createdEstadoParqueadero = await _estadoParqueaderoService.CreateEstadoParqueaderoAsync(estadoParqueadero);
            return CreatedAtAction(nameof(GetEstadoParqueadero), new { id = createdEstadoParqueadero.EstadoParqueaderoId }, createdEstadoParqueadero);
        }

        // PUT: api/EstadoParqueadero/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoParqueadero>> UpdateEstadoParqueadero(int id, GestionResidenciaApi.Models.EstadoParqueadero estadoParqueadero)
        {
            var updatedEstadoParqueadero = await _estadoParqueaderoService.UpdateEstadoParqueaderoAsync(id, estadoParqueadero);
            if (updatedEstadoParqueadero is null) return NotFound();
            return Ok(updatedEstadoParqueadero);
        }

        // DELETE: api/EstadoParqueadero/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoParqueadero>> DeleteEstadoParqueadero(int id)
        {
            var success = await _estadoParqueaderoService.DeleteEstadoParqueaderoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
