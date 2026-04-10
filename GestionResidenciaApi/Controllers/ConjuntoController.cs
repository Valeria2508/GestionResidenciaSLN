using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConjuntoController : ControllerBase
    {
        private readonly IConjunto _conjuntoService;

        public ConjuntoController(IConjunto conjuntoService)
        {
            _conjuntoService = conjuntoService;
        }

        // GET: api/Conjunto
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Conjunto>>> GetConjunto()
        {
            var conjunto = await _conjuntoService.GetConjuntosAsync();
            return Ok(conjunto);
        }

        // GET: api/Conjunto por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Conjunto>> GetConjuntos(int id)
        {
            var conjunto = await _conjuntoService.GetConjuntoByIdAsync(id);
            if (conjunto is null) return NotFound();
            return Ok(conjunto);
        }

        // POST: api/Conjunto
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Conjunto>> CreateConjunto(GestionResidenciaApi.Models.Conjunto conjunto)
        {
            var createdConjunto = await _conjuntoService.CreateConjuntoAsync(conjunto);
            return CreatedAtAction(nameof(GetConjuntos), new { id = createdConjunto.ConjuntoId }, createdConjunto);
        }

        // PUT: api/Conjunto/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Conjunto>> UpdateConjunto(int id, GestionResidenciaApi.Models.Conjunto conjunto)
        {
            var updatedConjunto = await _conjuntoService.UpdateConjuntoAsync(id, conjunto);
            if (updatedConjunto is null) return NotFound();
            return Ok(updatedConjunto);
        }

        // DELETE: api/Conjunto/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Conjunto>> DeleteConjunto(int id)
        {
            var success = await _conjuntoService.DeleteConjuntoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
