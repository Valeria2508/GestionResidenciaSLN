using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCuotaController : ControllerBase
    {
        private readonly IEstadoCuota _estadoCuotaService;

        public EstadoCuotaController(IEstadoCuota estadoCuotaService)
        {
            _estadoCuotaService = estadoCuotaService;
        }

        // GET: api/EstadoCuota
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.EstadoCuota>>> GetEstadoCuota()
        {
            var estadoCuotas = await _estadoCuotaService.GetEstadoCuotaAsync();
            return Ok(estadoCuotas);
        }

        // GET: api/EstadoCuota por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoCuota>> GetEstadoCuotas(int id)
        {
            var estadoCuotas = await _estadoCuotaService.GetEstadoCuotaByIdAsync(id);
            if (estadoCuotas is null) return NotFound();
            return Ok(estadoCuotas);
        }

        // POST: api/EstadoCuota
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoCuota>> CreateEstadoCuota(GestionResidenciaApi.Models.EstadoCuota estadoCuota)
        {
            var createdEstadocuota = await _estadoCuotaService.CreateEstadoCuotaAsync(estadoCuota);
            return CreatedAtAction(nameof(GetEstadoCuota), new { id = createdEstadocuota.EstadoCuotaId }, createdEstadocuota);
        }

        // PUT: api/EstadoCuota/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoCuota>> UpdateEstadoCuota(int id, GestionResidenciaApi.Models.EstadoCuota estadoCuota)
        {
            var updatedEstadocuota = await _estadoCuotaService.UpdateEstadoCuotaAsync(id, estadoCuota);
            if (updatedEstadocuota is null) return NotFound();
            return Ok(updatedEstadocuota);
        }

        // DELETE: api/EstadoCuota/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.EstadoCuota>> DeleteEstadoCuota(int id)
        {
            var success = await _estadoCuotaService.DeleteEstadoCuotaAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
