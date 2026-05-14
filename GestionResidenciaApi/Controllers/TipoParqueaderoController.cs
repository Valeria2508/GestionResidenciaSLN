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
    public class TipoParqueaderoController : ControllerBase
    {
        private readonly ITipoParqueadero _tipoParqueaderoService;

        public TipoParqueaderoController(ITipoParqueadero tipoParqueaderoService)
        {
            _tipoParqueaderoService = tipoParqueaderoService;
        }

        // GET: api/TipoParqueadero
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoParqueadero>>> GetTipoParqueadero()
        {
            var tipoParqueadero = await _tipoParqueaderoService.GetTipoParqueaderoAsync();
            return Ok(tipoParqueadero);
        }

        // GET: api/TipoParqueadero/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoParqueaderoCreateDTO>> GetTipoParqueaderoById(int id)
        {
            var tipoParqueadero = await _tipoParqueaderoService.GetTipoParqueaderoByIdAsync(id);

            if (tipoParqueadero is null)
                return NotFound(new { message = "TipoParqueadero no encontrado" });

            var dto = new TipoParqueaderoCreateDTO
            {
                TipoParqueaderoId = tipoParqueadero.TipoParqueaderoId,
                Nombre = tipoParqueadero.Nombre
            };

            return Ok(dto);
        }

        // POST: api/TipoParqueadero
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(TipoParqueaderoCreateDTO dto)
        {
            var tipoParqueadero = new TipoParqueadero
            {
                // Do not set TipoParqueaderoId when creating a new entity - it's an IDENTITY/primary key
                Nombre = dto.Nombre
            };

            await _tipoParqueaderoService.CreateTipoParqueaderoAsync(tipoParqueadero);

            return Ok(tipoParqueadero);
        }

        // PUT: api/TipoParqueadero/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTipoParqueadero(int id, TipoParqueaderoCreateDTO dto)
        {
            var updatedTipoParqueadero = await _tipoParqueaderoService.UpdateTipoParqueaderoAsync(id, dto);

            if (updatedTipoParqueadero == null)
                return NotFound();

            return Ok(new
            {
                message = "TipoParqueadero actualizado correctamente"
            });
        }

        // DELETE: api/TipoParqueadero/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTipoParqueadero(int id)
        {
            try
            {
                var success = await _tipoParqueaderoService.DeleteTipoParqueaderoAsync(id);
                if (!success)
                    return NotFound(new { message = "TipoParqueadero no encontrado" });

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