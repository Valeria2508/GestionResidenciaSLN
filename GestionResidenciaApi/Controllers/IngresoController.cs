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
        public async Task<ActionResult<IEnumerable<Ingreso>>> GetIngreso()
        {
            var ingresos = await _ingresoService.GetIngresoAsync();
            return Ok(ingresos);
        }

        // GET: api/Ingreso/5
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
                VisitanteId = ingreso.VisitanteId
            };

            return Ok(dto);
        }

        // POST: api/Ingreso
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] IngresoDTO dto)
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

        // PUT: api/Ingreso/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ingreso>> UpdateIngreso(int id, [FromBody] Ingreso ingreso)
        {
            if (id != ingreso.IngresoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedIngreso = await _ingresoService.UpdateIngresoAsync(id, ingreso);

            if (updatedIngreso is null)
                return NotFound(new { message = "Ingreso no encontrado" });

            return Ok(updatedIngreso);
        }

        // DELETE: api/Ingreso/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIngreso(int id)
        {
            var success = await _ingresoService.DeleteIngresoAsync(id);

            if (!success)
                return NotFound(new { message = "Ingreso no encontrado" });

            return NoContent();
        }
    }
}