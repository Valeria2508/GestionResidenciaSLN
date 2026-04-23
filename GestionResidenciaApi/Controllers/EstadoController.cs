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
    public class EstadoController : ControllerBase
    {
        private readonly IEstado _estadoService;

        public EstadoController(IEstado estadoService)
        {
            _estadoService = estadoService;
        }

        // GET: api/Estado
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
            var estados = await _estadoService.GetEstadosAsync();
            return Ok(estados);
        }

        // GET: api/Estado/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstadoDTO>> GetEstadoById(int id)
        {
            var estado = await _estadoService.GetEstadoByIdAsync(id);

            if (estado is null)
                return NotFound(new { message = "Estado no encontrado" });

            var dto = new EstadoDTO
            {
                EstadoId = estado.EstadoId
            };

            return Ok(dto);
        }

        // POST: api/Estado
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] EstadoDTO dto)
        {
            var estado = new Estado
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                TipoEstado = dto.TipoEstado
            };

            await _estadoService.CreateEstadoAsync(estado);
            return Ok(estado);
        }

        // PUT: api/Estado/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Estado>> UpdateEstado(int id, [FromBody] Estado estado)
        {
            if (id != estado.EstadoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedEstado = await _estadoService.UpdateEstadoAsync(id, estado);

            if (updatedEstado is null)
                return NotFound(new { message = "Estado no encontrado" });

            return Ok(updatedEstado);
        }

        // DELETE: api/Estado/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            var success = await _estadoService.DeleteEstadoAsync(id);

            if (!success)
                return NotFound(new { message = "Estado no encontrado" });

            return NoContent();
        }
    }
}