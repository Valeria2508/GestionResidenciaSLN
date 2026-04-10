using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaComunController : ControllerBase
    {
        private readonly IZonaComun _zonaComunService;

        public ZonaComunController(IZonaComun zonaComunService)
        {
            _zonaComunService = zonaComunService;
        }

        // GET: api/ZonaComun
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.ZonaComun>>> GetZonasComunes()
        {
            var zonasComunes = await _zonaComunService.GetZonaComunAsync();
            return Ok(zonasComunes);
        }

        // GET: api/ZonaComun por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ZonaComun>> GetZonaComun(int id)
        {
            var zonaComun = await _zonaComunService.GetZonaComunByIdAsync(id);
            if (zonaComun is null) return NotFound();
            return Ok(zonaComun);
        }

        // POST: api/ZonaComun
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ZonaComun>> CreateZonaComun(GestionResidenciaApi.Models.ZonaComun zonaComun)
        {
            var createdZonaComun = await _zonaComunService.CreateZonaComunAsync(zonaComun);
            return CreatedAtAction(nameof(GetZonaComun), new { id = createdZonaComun.ZonaComunId }, createdZonaComun);
        }

        // PUT: api/ZonaComun/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ZonaComun>> UpdateZonaComun(int id, GestionResidenciaApi.Models.ZonaComun zonaComun)
        {
            var updatedZonaComun = await _zonaComunService.UpdateZonaComunAsync(id, zonaComun);
            if (updatedZonaComun is null) return NotFound();
            return Ok(updatedZonaComun);
        }

        // DELETE: api/ZonaComun/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ZonaComun>> DeleteZonaComun(int id)
        {
            var success = await _zonaComunService.DeleteZonaComunAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
