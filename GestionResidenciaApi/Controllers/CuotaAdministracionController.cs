using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuotaAdministracionController : ControllerBase
    {
        private readonly ICuotaAdministracion _cuotaAdministracionService;

        public CuotaAdministracionController(ICuotaAdministracion cuotaAdministracionService)
        {
            _cuotaAdministracionService = cuotaAdministracionService;
        }

        // GET: api/CuotaAdministracion
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.CuotaAdministracion>>> GetCuotasAdministracion()
        {
            var cuotas = await _cuotaAdministracionService.GetCuotasAdministracionAsync();
            return Ok(cuotas);
        }

        // GET: api/CuotaAdministracion por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.CuotaAdministracion>> GetCuotaAdministracion(int id)
        {
            var cuota = await _cuotaAdministracionService.GetCuotaAdministracionByIdAsync(id);
            if (cuota is null) return NotFound();
            return Ok(cuota);
        }

        // POST: api/CuotaAdministracion
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.CuotaAdministracion>> CreateCuotaAdministracion(GestionResidenciaApi.Models.CuotaAdministracion cuota)
        {
            var createdCuota = await _cuotaAdministracionService.CreateCuotaAdministracionAsync(cuota);
            return CreatedAtAction(nameof(GetCuotaAdministracion), new { id = createdCuota.CuotaId }, createdCuota);
        }

        // PUT: api/CuotaAdministracion/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.CuotaAdministracion>> UpdateCuotaAdministracion(int id, GestionResidenciaApi.Models.CuotaAdministracion cuota)
        {
            var updatedCuota = await _cuotaAdministracionService.UpdateCuotaAdministracionAsync(id, cuota);
            if (updatedCuota is null) return NotFound();
            return Ok(updatedCuota);
        }

        // DELETE: api/CuotaAdministracion/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.CuotaAdministracion>> DeleteCuotaAdministracion(int id)
        {
            var success = await _cuotaAdministracionService.DeleteCuotaAdministracionAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
