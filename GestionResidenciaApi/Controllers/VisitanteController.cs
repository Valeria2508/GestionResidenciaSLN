using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitanteController : ControllerBase
    {
        private readonly IVisitante _visitanteService;

        public VisitanteController(IVisitante visitanteService)
        {
            _visitanteService = visitanteService;
        }

        // GET: api/Visitantes
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Visitante>>> GetVisitantes()
        {
            var visitantes = await _visitanteService.GetVisitanteAsync();
            return Ok(visitantes);
        }

        // GET: api/Visitantes por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Visitante>> GetVisitante(int id)
        {
            var visitante = await _visitanteService.GetVisitanteByIdAsync(id);
            if (visitante is null) return NotFound();
            return Ok(visitante);
        }

        // POST: api/Visitantes
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Visitante>> CreateVisitante(GestionResidenciaApi.Models.Visitante visitante)
        {
            var createdVisitante = await _visitanteService.CreateVisitanteAsync(visitante);
            return CreatedAtAction(nameof(GetVisitante), new { id = createdVisitante.VisitanteId }, createdVisitante);
        }

        // PUT: api/Visitantes/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Visitante>> UpdateVisitante(int id, GestionResidenciaApi.Models.Visitante visitante)
        {
            var updatedVisitante = await _visitanteService.UpdateVisitanteAsync(id, visitante);
            if (updatedVisitante is null) return NotFound();
            return Ok(updatedVisitante);
        }

        // DELETE: api/Visitantes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Visitante>> DeleteVisitante(int id)
        {
            var success = await _visitanteService.DeleteVisitanteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
