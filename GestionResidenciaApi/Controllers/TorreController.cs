using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorreController : ControllerBase
    {
        private readonly ITorre _torreService;

        public TorreController(ITorre torreService)
        {
            _torreService = torreService;
        }

        // GET: api/Torre
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Torre>>> GetTorres()
        {
            var torres = await _torreService.GetTorreAsync();
            return Ok(torres);
        }

        // GET: api/Apartamentos por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Torre>> GetTorre(int id)
        {
            var torre = await _torreService.GetTorreByIdAsync(id);
            if (torre is null) return NotFound();
            return Ok(torre);
        }

        // POST: api/Torre
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Torre>> CreateTorre(GestionResidenciaApi.Models.Torre torre)
        {
            var createdTorre = await _torreService.CreateTorreAsync(torre);
            return CreatedAtAction(nameof(GetTorre), new { id = createdTorre.TorreId }, createdTorre);
        }

        // PUT: api/Torre/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Torre>> UpdateTorre(int id, GestionResidenciaApi.Models.Torre torre)
        {
            var updatedTorre = await _torreService.UpdateTorreAsync(id, torre);
            if (updatedTorre is null) return NotFound();
            return Ok(updatedTorre);
        }

        // DELETE: api/Torre/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Torre>> DeleteTorre(int id)
        {
            var success = await _torreService.DeleteTorreAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
