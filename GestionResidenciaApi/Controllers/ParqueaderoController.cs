using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueaderoController : ControllerBase
    {
        private readonly IParqueadero _parqueaderoService;

        public ParqueaderoController(IParqueadero parqueaderoService)
        {
            _parqueaderoService = parqueaderoService;
        }

        // GET: api/Parqueadero
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Parqueadero>>> GetParqueaderos()
        {
            var parqueaderos = await _parqueaderoService.GetParqueaderoAsync();
            return Ok(parqueaderos);
        }

        // GET: api/Parqueadero por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Parqueadero>> GetParqueadero(int id)
        {
            var parqueadero = await _parqueaderoService.GetParqueaderoByIdAsync(id);
            if (parqueadero is null) return NotFound();
            return Ok(parqueadero);
        }

        // POST: api/Parqueadero
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Parqueadero>> CreateParqueadero(GestionResidenciaApi.Models.Parqueadero parqueadero)
        {
            var createdParqueadero = await _parqueaderoService.CreateParqueaderoAsync(parqueadero);
            return CreatedAtAction(nameof(GetParqueadero), new { id = createdParqueadero.ParqueaderoId }, createdParqueadero);
        }

        // PUT: api/Parqueadero/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Parqueadero>> UpdateParqueadero(int id, GestionResidenciaApi.Models.Parqueadero parqueadero)
        {
            var updatedParqueadero = await _parqueaderoService.UpdateParqueaderoAsync(id, parqueadero);
            if (updatedParqueadero is null) return NotFound();
            return Ok(updatedParqueadero);
        }

        // DELETE: api/Parqueadero/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Parqueadero>> DeleteParqueadero(int id)
        {
            var success = await _parqueaderoService.DeleteParqueaderoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
