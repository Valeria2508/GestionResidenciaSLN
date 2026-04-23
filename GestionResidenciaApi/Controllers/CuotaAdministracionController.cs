using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CuotaAdministracionController : ControllerBase
    {
        private readonly ICuotaAdministracion _cuotaAdministracionService;

        public CuotaAdministracionController(ICuotaAdministracion cuotaAdministracionService)
        {
            _cuotaAdministracionService = cuotaAdministracionService;
        }

        // GET: api/CuotaAdministracion
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CuotaAdministracion>>> GetCuotaAdministracion()
        {
            var cuotaAdministracion = await _cuotaAdministracionService.GetCuotasAdministracionAsync();
            return Ok(cuotaAdministracion);
        }

        // GET: api/CuotaAdministracion/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CuotaCreateDTO>> GetCuotaAdministracionById(int id)
        {
            var cuotaAdmin = await _cuotaAdministracionService.GetCuotaAdministracionByIdAsync(id);

            if (cuotaAdmin is null)
                return NotFound(new { message = "CuotaAdministracion no encontrado" });

            var dto = new CuotaCreateDTO
            {
                UnidadId = cuotaAdmin.UnidadId,
                EstadoId = cuotaAdmin.EstadoId
            };

            return Ok(dto);
        }

        // POST: api/CuotaAdministracion
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(CuotaCreateDTO dto)
        {
            var cuota = new CuotaAdministracion
            {
                UnidadId = dto.UnidadId,
                EstadoId = dto.EstadoId,
                Periodo = dto.Periodo,
                Valor = dto.Valor,
                FechaLimite = dto.FechaLimite,
                SaldoPendiente = dto.SaldoPendiente,
                Observacion = dto.Observacion
            };

            await _cuotaAdministracionService.CreateCuotaAdministracionAsync(cuota);

            return Ok(cuota);
        }

        // PUT: api/CuotaAdministracion/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CuotaAdministracion>> UpdateCuotaAdministracion(int id, [FromBody] CuotaAdministracion cuotaAdministracion)
        {
            if (id != cuotaAdministracion.UnidadId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedCuotaAdministracion = await _cuotaAdministracionService.UpdateCuotaAdministracionAsync(id, cuotaAdministracion);

            if (updatedCuotaAdministracion is null)
                return NotFound(new { message = "CuotaAdministracion no encontrado" });

            return Ok(updatedCuotaAdministracion);
        }

        // DELETE: api/CuotaAdministracion/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCuotaAdministracion(int id)
        {
            var success = await _cuotaAdministracionService.DeleteCuotaAdministracionAsync(id);

            if (!success)
                return NotFound(new { message = "CuotaAdministracion no encontrado" });

            return NoContent();
        }
    }
}