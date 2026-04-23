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
    public class TorreController : ControllerBase
    {
        private readonly ITorre _torreService;

        public TorreController(ITorre torreService)
        {
            _torreService = torreService;
        }

        // GET: api/Torre
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Torre>>> GetTorre()
        {
            var torres = await _torreService.GetTorreAsync();
            return Ok(torres);
        }

        // GET: api/Torre/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TorreCreateDTO>> GetTorreById(int id)
        {
            var torre = await _torreService.GetTorreByIdAsync(id);

            if (torre is null)
                return NotFound(new { message = "Torre no encontrada" });

            var dto = new TorreCreateDTO
            {
                TorreId = torre.TorreId,
                Nombre = torre.Nombre,
                ConjuntoId = torre.ConjuntoId
            };

            return Ok(dto);
        }

        // POST: api/Torre
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Create(TorreCreateDTO dto)
        {
            var torre = new Torre
            {
                ConjuntoId = dto.ConjuntoId,
                Nombre = dto.Nombre
            };

            await _torreService.CreateTorreAsync(torre);

            return Ok(torre);
        }

        // PUT: api/Torre/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Torre>> UpdateTorre(int id, [FromBody] Torre torre)
        {
            if (id != torre.TorreId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedTorre = await _torreService.UpdateTorreAsync(id, torre);

            if (updatedTorre is null)
                return NotFound(new { message = "Torre no encontrada" });

            return Ok(updatedTorre);
        }

        // DELETE: api/Torre/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTorre(int id)
        {
            var success = await _torreService.DeleteTorreAsync(id);

            if (!success)
                return NotFound(new { message = "Torre no encontrada" });

            return NoContent();
        }
    }
}