using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidenteUnidadController : ControllerBase
    {
        private readonly IResidenteUnidad _residenteUnidadService;

        public ResidenteUnidadController(IResidenteUnidad residenteUnidadService)
        {
            _residenteUnidadService = residenteUnidadService;
        }

        // GET: api/ResidenteUnidad
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.ResidenteUnidad>>> GetResidenteUnidades()
        {
            var residenteUnidades = await _residenteUnidadService.GetResidenteUnidadAsync();
            return Ok(residenteUnidades);
        }

        // GET: api/ResidenteUnidad por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ResidenteUnidad>> GetResidenteUnidad(int id)
        {
            var residenteUnidad = await _residenteUnidadService.GetResidenteUnidadByIdAsync(id);
            if (residenteUnidad is null) return NotFound();
            return Ok(residenteUnidad);
        }

        // POST: api/ResidenteUnidad
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ResidenteUnidad>> CreateResidenteUnidad(GestionResidenciaApi.Models.ResidenteUnidad residenteUnidad)
        {
            var createdResidenteUnidad = await _residenteUnidadService.CreateResidenteUnidadAsync(residenteUnidad);
            return CreatedAtAction(nameof(GetResidenteUnidad), new { id = createdResidenteUnidad.UnidadId }, createdResidenteUnidad);
        }

        // PUT: api/ResidenteUnidad/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ResidenteUnidad>> UpdateResidenteUnidad(int id, GestionResidenciaApi.Models.ResidenteUnidad residenteUnidad)
        {
            var updatedResidenteUnidad = await _residenteUnidadService.UpdateResidenteUnidadAsync(id, residenteUnidad);
            if (updatedResidenteUnidad is null) return NotFound();
            return Ok(updatedResidenteUnidad);
        }

        // DELETE: api/ResidenteUnidad/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.ResidenteUnidad>> DeleteResidenteUnidad(int id)
        {
            var success = await _residenteUnidadService.DeleteResidenteUnidadAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
