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
    public class TipoIngresoController : ControllerBase
    {
        private readonly ITipoIngreso _tipoIngresoService;

        public TipoIngresoController(ITipoIngreso tipoIngresoService)
        {
            _tipoIngresoService = tipoIngresoService;
        }

        // GET: api/TipoIngreso
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TipoIngreso>>> GetTipoIngreso()
        {
            var tipoIngreso = await _tipoIngresoService.GetTipoIngresoAsync();
            return Ok(tipoIngreso);
        }

        // GET: api/TipoIngreso/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TipoIngresoDTO>> GetTipoIngresoById(int id)
        {
            var tipoIngreso = await _tipoIngresoService.GetTipoIngresoByIdAsync(id);

            if (tipoIngreso is null)
                return NotFound(new { message = "TipoIngreso no encontrado" });

            var dto = new TipoIngresoDTO
            {
                TipoIngresoId = tipoIngreso.TipoIngresoId,
                Nombre = tipoIngreso.Nombre
            };

            return Ok(dto);
        }

        // POST: api/TipoIngreso
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(TipoIngresoDTO dto)
        {
            var tipoIngreso = new TipoIngreso
            {
                // Do not set TipoIngresoId when creating a new entity - it's an IDENTITY/primary key
                Nombre = dto.Nombre
            };

            await _tipoIngresoService.CreateTipoIngresoAsync(tipoIngreso);

            return Ok(tipoIngreso);
        }

        // PUT: api/TipoIngreso/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateTipoIngreso(int id, TipoIngresoDTO dto)
        {
            var updatedTipoIngreso = await _tipoIngresoService.UpdateTipoIngresoAsync(id, dto);

            if (updatedTipoIngreso == null)
                return NotFound();

            return Ok(new
            {
                message = "TipoIngreso actualizado correctamente"
            });
        }

        // DELETE: api/TipoIngreso/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTipoIngreso(int id)
        {
            try
            {
                var success = await _tipoIngresoService.DeleteTipoIngresoAsync(id);
                if (!success)
                    return NotFound(new { message = "TipoIngreso no encontrado" });

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