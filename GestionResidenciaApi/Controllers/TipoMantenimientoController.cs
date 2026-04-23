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
    public class TipoMantenimientoController : ControllerBase
    {
        private readonly ITipoMantenimiento _tipoMantenimientoService;

        public TipoMantenimientoController(ITipoMantenimiento tipoMantenimientoService)
        {
            _tipoMantenimientoService = tipoMantenimientoService;
        }

        // GET: api/TipoMantenimiento
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoMantenimiento>>> GetTipoMantenimiento()
        {
            var tipoMantenimiento = await _tipoMantenimientoService.GetTipoMantenimientoAsync();
            return Ok(tipoMantenimiento);
        }

        // GET: api/TipoMantenimiento/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoMantenimientoCreateDTO>> GetTipoMantenimientoById(int id)
        {
            var tipoMantenimiento = await _tipoMantenimientoService.GetTipoMantenimientoByIdAsync(id);

            if (tipoMantenimiento is null)
                return NotFound(new { message = "TipoMantenimiento no encontrado" });

            var dto = new TipoMantenimientoCreateDTO
            {
                TipoMantenimientoId = tipoMantenimiento.TipoMantenimientoId,
                Nombre = tipoMantenimiento.Nombre
            };

            return Ok(dto);
        }

        // POST: api/TipoMantenimiento
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TipoMantenimientoCreateDTO dto)
        {
            var tipoMantenimiento = new TipoMantenimiento
            {
                Nombre = dto.Nombre
            };

            await _tipoMantenimientoService.CreateTipoMantenimientoAsync(tipoMantenimiento);
            return Ok(tipoMantenimiento);
        }

        // PUT: api/TipoMantenimiento/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoMantenimiento>> UpdateTipoMantenimiento(int id, [FromBody] TipoMantenimiento tipoMantenimiento)
        {
            if (id != tipoMantenimiento.TipoMantenimientoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedTipoMantenimiento = await _tipoMantenimientoService.UpdateTipoMantenimientoAsync(id, tipoMantenimiento);

            if (updatedTipoMantenimiento is null)
                return NotFound(new { message = "TipoMantenimiento no encontrado" });

            return Ok(updatedTipoMantenimiento);
        }

        // DELETE: api/TipoMantenimiento/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTipoMantenimiento(int id)
        {
            var success = await _tipoMantenimientoService.DeleteTipoMantenimientoAsync(id);

            if (!success)
                return NotFound(new { message = "TipoMantenimiento no encontrado" });

            return NoContent();
        }
    }
}