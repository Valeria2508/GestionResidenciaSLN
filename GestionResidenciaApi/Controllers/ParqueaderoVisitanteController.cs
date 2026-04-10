using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueaderoVisitanteController : ControllerBase
    {
        private readonly IParqueaderoVisitante _parqueaderoVisitanteService;

        public ParqueaderoVisitanteController(IParqueaderoVisitante parqueaderoVisitanteService)
        {
            _parqueaderoVisitanteService = parqueaderoVisitanteService;
        }

        // GET: api/ParqueaderoVisitante
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.ParqueaderoVisitante>>> GetParqueaderoVisitantes()
        {
            var parqueaderoVisitantes = await _parqueaderoVisitanteService.GetParqueaderoVisitanteAsync();
            return Ok(parqueaderoVisitantes);
        }

        // GET: api/ParqueaderoVisitante por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ParqueaderoVisitante>> GetParqueadedroVisitante(int id)
        {
            var parqueaderoVisitante = await _parqueaderoVisitanteService.GetParqueaderoVisitanteByIdAsync(id);
            if (parqueaderoVisitante is null) return NotFound();
            return Ok(parqueaderoVisitante);
        }

        // POST: api/ParqueaderoVisitante
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ParqueaderoVisitante>> CreateParqueaderoVisitante(GestionResidenciaApi.Models.ParqueaderoVisitante parqueaderoVisitante)
        {
            var createdParqueaderoVisitante = await _parqueaderoVisitanteService.CreateParqueaderoVisitanteAsync(parqueaderoVisitante);
            return CreatedAtAction(nameof(GetParqueadedroVisitante), new { id = createdParqueaderoVisitante.ParqueaderoVisitanteId }, createdParqueaderoVisitante);
        }

        // PUT: api/ParqueaderoVisitante/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ParqueaderoVisitante>> UpdateParqueaderoVisitante(int id, GestionResidenciaApi.Models.ParqueaderoVisitante parqueaderoVisitante)
        {
            var updatedParqueaderoVisitante = await _parqueaderoVisitanteService.UpdateParqueaderoVisitanteAsync(id, parqueaderoVisitante);
            if (updatedParqueaderoVisitante is null) return NotFound();
            return Ok(updatedParqueaderoVisitante);
        }

        // DELETE: api/ParqueaderoVisitante/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ParqueaderoVisitante>> DeleteParqueaderoVisitante(int id)
        {
            var success = await _parqueaderoVisitanteService.DeleteParqueaderoVisitanteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
