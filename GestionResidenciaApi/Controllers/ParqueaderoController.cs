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
    public class ParqueaderoController : ControllerBase
    {
        private readonly IParqueadero _parqueaderoService;

        public ParqueaderoController(IParqueadero parqueaderoService)
        {
            _parqueaderoService = parqueaderoService;
        }

        // GET: api/Parqueadero
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Parqueadero>>> GetParqueadero()
        {
            var parqueaderos = await _parqueaderoService.GetParqueaderoAsync();
            return Ok(parqueaderos);
        }

        // GET: api/Parqueadero/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ParqueaderoDTO>> GetParqueaderoById(int id)
        {
            var parqueadero = await _parqueaderoService.GetParqueaderoByIdAsync(id);

            if (parqueadero is null)
                return NotFound(new { message = "Parqueadero no encontrado" });

            var dto = new ParqueaderoDTO
            {
                UnidadId = parqueadero.UnidadId,
                TipoParqueaderoId = parqueadero.TipoParqueaderoId,
                EstadoId = parqueadero.EstadoId,
                Numero = parqueadero.Numero
            };
            

            return Ok(dto);
        }
        // POST: api/Parqueadero
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(ParqueaderoDTO dto)
        {
            var parqueadero = new Parqueadero
            {
                UnidadId = dto.UnidadId,
                TipoParqueaderoId = dto.TipoParqueaderoId,
                EstadoId = dto.EstadoId,
                Numero = dto.Numero
            };
            await _parqueaderoService.CreateParqueaderoAsync(parqueadero);

            return Ok(parqueadero);
        }

        // PUT: api/Parqueadero/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateParqueadero(int id, ParqueaderoDTO dto)
        {
            var updatedParqueadero = await _parqueaderoService.UpdateParqueaderoAsync(id, dto);

            if (updatedParqueadero == null)
                return NotFound();

            return Ok(new
            {
                message = "Parqueadero actualizado correctamente"
            });
        }

        // DELETE: api/Parqueadero/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParqueadero(int id)
        {
            try
            {
                var success = await _parqueaderoService.DeleteParqueaderoAsync(id);
                if (!success)
                    return NotFound(new { message = "Parqueadero no encontrado" });

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