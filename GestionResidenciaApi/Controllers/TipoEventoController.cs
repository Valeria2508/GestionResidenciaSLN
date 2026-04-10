using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEvento _tipoEventoService;

        public TipoEventoController(ITipoEvento tipoEventoService)
        {
            _tipoEventoService = tipoEventoService;
        }

        // GET: api/TipoEvento
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.TipoEvento>>> GetTipoEventos()
        {
            var tipoEventos = await _tipoEventoService.GetTipoEventoAsync();
            return Ok(tipoEventos);
        }

        // GET: api/TipoEvento por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoEvento>> GetTipoEvento(int id)
        {
            var tipoEvento = await _tipoEventoService.GetTipoEventoByIdAsync(id);
            if (tipoEvento is null) return NotFound();
            return Ok(tipoEvento);
        }

        // POST: api/TipoEvento
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoEvento>> CreateTipoEvento(GestionResidenciaApi.Models.TipoEvento tipoEvento)
        {
            var createdTipoEvento = await _tipoEventoService.CreateTipoEventoAsync(tipoEvento);
            return CreatedAtAction(nameof(GetTipoEvento), new { id = createdTipoEvento.TipoEventoId }, createdTipoEvento);
        }

        // PUT: api/TipoEvento/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoEvento>> UpdateTipoEvento(int id, GestionResidenciaApi.Models.TipoEvento tipoEvento)
        {
            var updatedTipoEvento = await _tipoEventoService.UpdateTipoEventoAsync(id, tipoEvento);
            if (updatedTipoEvento is null) return NotFound();
            return Ok(updatedTipoEvento);
        }

        // DELETE: api/TipoEvento/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.TipoEvento>> DeleteTipoEvento(int id)
        {
            var success = await _tipoEventoService.DeleteTipoEventoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
