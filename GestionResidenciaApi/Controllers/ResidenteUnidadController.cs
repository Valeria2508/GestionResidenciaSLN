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
    public class ResidenteUnidadController : ControllerBase
    {
        private readonly IResidenteUnidad _residenteUnidadService;

        public ResidenteUnidadController(IResidenteUnidad residenteUnidadService)
        {
            _residenteUnidadService = residenteUnidadService;
        }

        // GET: api/ResidenteUnidad
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ResidenteUnidad>>> GetResidenteUnidad()
        {
            var residenteUnidad = await _residenteUnidadService.GetResidenteUnidadAsync();
            return Ok(residenteUnidad);
        }

        // GET: api/ResidenteUnidad/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResidenteUnidadDTO>> GetResidenteUnidadById(int id)
        {
            var residenteUnidad = await _residenteUnidadService.GetResidenteUnidadByIdAsync(id);

            if (residenteUnidad is null)
                return NotFound(new { message = "ResidenteUnidad no encontrado" });

            var dto = new ResidenteUnidadDTO
            {
                ResidenteUnidadId = residenteUnidad.ResidenteUnidadId,
                UnidadId = residenteUnidad.UnidadId,
                UsuarioId = residenteUnidad.UsuarioId,
                EsPropietario = residenteUnidad.EsPropietario,
                FechaInicio = residenteUnidad.FechaInicio,
                FechaFin = residenteUnidad.FechaFin,
                Observacion = residenteUnidad.Observacion
            };

            return Ok(dto);
        }

        // POST: api/ResidenteUnidad
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(ResidenteUnidadDTO dto)
        {
            var residenteUnidad = new ResidenteUnidad
            {
                // Do not set ResidenteUnidadId when creating a new entity - it's an IDENTITY column
                UnidadId = dto.UnidadId,
                UsuarioId = dto.UsuarioId,
                EsPropietario = dto.EsPropietario,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Observacion = dto.Observacion
            };

            await _residenteUnidadService.CreateResidenteUnidadAsync(residenteUnidad);

            return Ok(residenteUnidad);
        }


        // PUT: api/ResidenteUnidad/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateResidenteUnidad(int id, ResidenteUnidadDTO dto)
        {
            var updatedResidenteUnidad = await _residenteUnidadService.UpdateResidenteUnidadAsync(id, dto);

            if (updatedResidenteUnidad == null)
                return NotFound();

            return Ok(new
            {
                message = "ResidenteUnidad actualizado correctamente"
            });
        }

        // DELETE: api/ResidenteUnidad/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteResidenteUnidad(int id)
        {
            try
            {
                var success = await _residenteUnidadService.DeleteResidenteUnidadAsync(id);
                if (!success)
                    return NotFound(new { message = "ResidenteUnidad no encontrado" });

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