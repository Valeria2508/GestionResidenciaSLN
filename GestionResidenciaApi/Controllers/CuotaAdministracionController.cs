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

        // GET: api/Conjunto
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CuotaAdministracion>>> GetCuotaAdministracion()
        {
            var cuotas = await _cuotaAdministracionService.GetCuotaAdministracionAsync();
            return Ok(cuotas);
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
                EstadoId = cuotaAdmin.EstadoId,
                Periodo = cuotaAdmin.Periodo,
                Valor = cuotaAdmin.Valor,
                FechaLimite = cuotaAdmin.FechaLimite,
                SaldoPendiente = cuotaAdmin.SaldoPendiente,
                Observacion = cuotaAdmin.Observacion

            };

            return Ok(dto);
        }

        // POST: api/Conjunto
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCuotaAdministracion(int id, CuotaCreateDTO dto)
        {
            try
            {
                var updated = await _cuotaAdministracionService.UpdateCuotaAdministracionAsync(id, dto);

                if (updated == null)
                    return NotFound(new { message = "Cuota no encontrada" });

                return Ok(new
                {
                    message = "Cuota actualizada correctamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        // DELETE: api/cuota/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCuota(int id)
        {
            try
            {
                var success = await _cuotaAdministracionService.DeleteCuotaAdministracionAsync(id);
                if (!success)
                    return NotFound(new { message = "CuotaAdministracion no encontrado" });

                return Ok(new
                {
                    message = "Registro eliminado correctamente"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }
    }
}