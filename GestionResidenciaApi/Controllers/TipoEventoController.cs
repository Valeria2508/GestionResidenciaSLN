using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
using GestionResidenciaApi.DTOs;

namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEvento _tipoEventoService;

        public TipoEventoController(ITipoEvento tipoEventoService)
        {
            _tipoEventoService = tipoEventoService;
        }

        // GET: api/TipoEvento
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoEvento>>> GetTipoEvento()
        {
            var tipoEvento = await _tipoEventoService.GetTipoEventoAsync();
            return Ok(tipoEvento);
        }

        // GET: api/TipoEvento/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoEventoDTO>> GetTipoEventoById(int id)
        {
            var tipoEvento = await _tipoEventoService.GetTipoEventoByIdAsync(id);

            if (tipoEvento is null)
                return NotFound(new { message = "TipoEvento no encontrado" });

            var dto = new TipoEventoDTO
            {
                TipoEventoId = tipoEvento.TipoEventoId
            };

            return Ok(dto);
        }

        // POST: api/TipoEvento
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TipoEventoDTO dto)
        {
            var tipoEvento = new TipoEvento
            {
                Nombre = dto.Nombre
            };

            await _tipoEventoService.CreateTipoEventoAsync(tipoEvento);
            return Ok(tipoEvento);
        }

        // PUT: api/TipoEvento/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoEvento>> UpdateTipoEvento(int id, [FromBody] TipoEvento tipoEvento)
        {
            if (id != tipoEvento.TipoEventoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedTipoEvento = await _tipoEventoService.UpdateTipoEventoAsync(id, tipoEvento);

            if (updatedTipoEvento is null)
                return NotFound(new { message = "TipoEvento no encontrado" });

            return Ok(updatedTipoEvento);
        }

        // DELETE: api/TipoEvento/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTipoEvento(int id)
        {
            var success = await _tipoEventoService.DeleteTipoEventoAsync(id);

            if (!success)
                return NotFound(new { message = "TipoEvento no encontrado" });

            return NoContent();
        }
    }
}