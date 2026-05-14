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
    public class IngresoController : ControllerBase
    {
        private readonly IIngreso _ingresoService;

        public IngresoController(IIngreso ingresoService)
        {
            _ingresoService = ingresoService;
        }

        // GET: api/Ingresos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngresos()
        {
            var ingresos = await _ingresoService.GetIngresoAsync();
            return Ok(ingresos);
        }

        // GET: api/Ingreso/5
        //[Authorize]
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IngresoDTO>> GetIngresoById(int id)
        {
            var ingreso = await _ingresoService.GetIngresoByIdAsync(id);

            if (ingreso is null)
                return NotFound(new { message = "Ingreso no encontrado" });

            var dto = new IngresoDTO
            {
                TipoIngresoId = ingreso.TipoIngresoId,
                UsuarioId = ingreso.UsuarioId,
                UnidadId = ingreso.UnidadId,
                VisitanteId = ingreso.VisitanteId,
                NombrePersona = ingreso.NombrePersona,
                Documento = ingreso.Documento,
                Vehiculo = ingreso.Vehiculo,
                FechaIngreso = ingreso.FechaHoraIngreso,
                FechaSalida = ingreso.FechaHoraSalida,
                Observacion = ingreso.Observacion
            };

            return Ok(dto);
        }

        // POST: api/Conjunto
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(IngresoDTO dto)
        {
            var ingreso = new Ingreso
            {
                TipoIngresoId = dto.TipoIngresoId,
                UsuarioId = dto.UsuarioId,
                UnidadId = dto.UnidadId,
                VisitanteId = dto.VisitanteId,
                NombrePersona = dto.NombrePersona,
                Documento = dto.Documento,
                Vehiculo = dto.Vehiculo,
                FechaHoraIngreso = dto.FechaIngreso,
                FechaHoraSalida = dto.FechaSalida,
                Observacion = dto.Observacion
            };

            await _ingresoService.CreateIngresoAsync(ingreso);
            return Ok(ingreso);
        }

        // PUT: api/Conjunto/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIngreso(int id, IngresoDTO dto)
        {
            var updatedIngreso = await _ingresoService.UpdateIngresoAsync(id, dto);

            if (updatedIngreso == null)
                return NotFound();

            return Ok(new
            {
                message = "Ingreso actualizado correctamente"
            });
        }


        // DELETE: api/Ingreso/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteIngreso(int id)
        {
            try
            {
                var success = await _ingresoService.DeleteIngresoAsync(id);
                if (!success)
                    return NotFound(new { message = "Ingreso no encontrado" });

                return Ok(new
                {
                    message = "Ingreso eliminado correctamente"
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