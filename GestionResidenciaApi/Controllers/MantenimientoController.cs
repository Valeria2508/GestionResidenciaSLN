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
    public class MantenimientoController : ControllerBase
    {
        private readonly IMantenimiento _mantenimientoService;

        public MantenimientoController(IMantenimiento mantenimientoService)
        {
            _mantenimientoService = mantenimientoService;
        }

        // GET: api/Mantenimiento
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Mantenimiento>>> GetMantenimiento()
        {
            var mantenimiento = await _mantenimientoService.GetMantenimientoAsync();
            return Ok(mantenimiento);
        }

        // GET: api/Mantenimiento/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MantenimientoDTO>> GetMantenimientoById(int id)
        {
            var mantenimiento = await _mantenimientoService.GetMantenimientoByIdAsync(id);

            if (mantenimiento is null)
                return NotFound(new { message = "Mantenimiento no encontrado" });

            var dto = new MantenimientoDTO
            {
                MantenimientoId = mantenimiento.MantenimientoId,
                ZonaComunId = mantenimiento.ZonaComunId,
                TipoMantenimientoId = mantenimiento.TipoMantenimientoId,
                UnidadId = mantenimiento.UnidadId
            };  

            return Ok(dto);
        }

        // POST: api/Mantenimiento
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] MantenimientoDTO dto)
        {
            var mantenimiento = new Mantenimiento
            {
                ZonaComunId = dto.ZonaComunId,
                TipoMantenimientoId = dto.TipoMantenimientoId,
                UnidadId = dto.UnidadId,
                Proveedor = dto.Proveedor,
                Fecha = dto.Fecha,
                Descripcion = dto.Descripcion,
                Costo = dto.Costo
            };

            await _mantenimientoService.CreateMantenimientoAsync(mantenimiento);
            return Ok(mantenimiento);
        }

        // PUT: api/Mantenimiento/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Mantenimiento>> UpdateMantenimiento(int id, [FromBody] Mantenimiento mantenimiento)
        {
            if (id != mantenimiento.MantenimientoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedMantenimiento = await _mantenimientoService.UpdateMantenimientoAsync(id, mantenimiento);

            if (updatedMantenimiento is null)
                return NotFound(new { message = "Mantenimiento no encontrado" });

            return Ok(updatedMantenimiento);
        }

        // DELETE: api/Mantenimiento/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMantenimiento(int id)
        {
            var success = await _mantenimientoService.DeleteMantenimientoAsync(id);

            if (!success)
                return NotFound(new { message = "Mantenimiento no encontrado" });

            return NoContent();
        }
    }
}