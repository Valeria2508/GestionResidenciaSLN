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
    public class ConjuntoController : ControllerBase
    {
        private readonly IConjunto _conjuntoService;

        public ConjuntoController(IConjunto conjuntoService)
        {
            _conjuntoService = conjuntoService;
        }

        // GET: api/Conjunto
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Conjunto>>> GetConjunto()
        {
            var conjunto = await _conjuntoService.GetConjuntosAsync();
            return Ok(conjunto);
        }

        // GET: api/Conjunto/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConjuntoCreateDTO>> GetConjuntoById(int id)
        {
            var conjunto = await _conjuntoService.GetConjuntoByIdAsync(id);

            if (conjunto is null)
                return NotFound(new { message = "Conjunto no encontrado" });

            var dto = new ConjuntoCreateDTO
            {
                ConjuntoId = conjunto.ConjuntoId,
            };

            return Ok(dto);
        }

        // POST: api/Conjunto
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(ConjuntoCreateDTO dto)
        {
            var conjunto = new Conjunto
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Ciudad = dto.Ciudad,
                NIT = dto.NIT,
                Telefono = dto.Telefono
            };

            await _conjuntoService.CreateConjuntoAsync(conjunto);

            return Ok(conjunto);
        }

        // PUT: api/Conjunto/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Conjunto>> UpdateConjunto(int id, [FromBody] Conjunto conjunto)
        {
            if (id != conjunto.ConjuntoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedConjunto = await _conjuntoService.UpdateConjuntoAsync(id, conjunto);

            if (updatedConjunto is null)
                return NotFound(new { message = "Conjunto no encontrado" });

            return Ok(updatedConjunto);
        }

        // DELETE: api/Conjunto/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteConjunto(int id)
        {
            var success = await _conjuntoService.DeleteConjuntoAsync(id);

            if (!success)
                return NotFound(new { message = "Conjunto no encontrado" });

            return NoContent();
        }
    }
}