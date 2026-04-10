using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngresoController : ControllerBase
    {
        private readonly IIngreso _ingresoService;

        public IngresoController(IIngreso ingresoService)
        {
            _ingresoService = ingresoService;
        }

        // GET: api/Apartamentos
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Ingreso>>> GetIngresos()
        {
            var ingresos = await _ingresoService.GetIngresoAsync();
            return Ok(ingresos);
        }

        // GET: api/Ingreso por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Ingreso>> GetIngreso(int id)
        {
            var ingreso = await _ingresoService.GetIngresoByIdAsync(id);
            if (ingreso is null) return NotFound();
            return Ok(ingreso);
        }

        // POST: api/Ingreso
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Ingreso>> CreateIngreso(GestionResidenciaApi.Models.Ingreso ingreso)
        {
            var createdIngreso = await _ingresoService.CreateIngresoAsync(ingreso);
            return CreatedAtAction(nameof(GetIngreso), new { id = createdIngreso.IngresoId }, createdIngreso);
        }

        // PUT: api/Ingreso/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Ingreso>> UpdateIngreso(int id, GestionResidenciaApi.Models.Ingreso ingreso)
        {
            var updatedIngreso = await _ingresoService.UpdateIngresoAsync(id, ingreso);
            if (updatedIngreso is null) return NotFound();
            return Ok(updatedIngreso);
        }

        // DELETE: api/Ingreso/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Ingreso>> DeleteIngreso(int id)
        {
            var success = await _ingresoService.DeleteIngresoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
