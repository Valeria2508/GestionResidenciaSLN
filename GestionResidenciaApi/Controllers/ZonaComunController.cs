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
    public class ZonaComunController : ControllerBase
    {
        private readonly IZonaComun _zonaComunService;

        public ZonaComunController(IZonaComun zonaComunService)
        {
            _zonaComunService = zonaComunService;
        }

        // GET: api/ZonaComun
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ZonaComun>>> GetZonasComunes()
        {
            var zonasComunes = await _zonaComunService.GetZonaComunAsync();
            return Ok(zonasComunes);
        }

        // GET: api/ZonaComun/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ZonaComunDTO>> GetZonaComunById(int id)
        {
            var zonaComun = await _zonaComunService.GetZonaComunByIdAsync(id);

            if (zonaComun is null)
                return NotFound(new { message = "Zona común no encontrada" });

            var dto = new ZonaComunDTO
            {
                ZonaComunId = zonaComun.ZonaComunId,
                ConjuntoId = zonaComun.ConjuntoId
            };

            return Ok(dto);
        }

        // POST: api/ZonaComun
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(ZonaComunDTO dto)
        {
            var zonaComun = new ZonaComun
            {
                ConjuntoId = dto.ConjuntoId,
                Nombre = dto.Nombre,
                Capacidad = dto.Capacidad,
                RequierePago = dto.RequierePago,
                ValorHora = dto.ValorHora
            };

            await _zonaComunService.CreateZonaComunAsync(zonaComun);

            return Ok(zonaComun);
        }

        // PUT: api/ZonaComun/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ZonaComun>> UpdateZonaComun(int id, [FromBody] ZonaComun zonaComun)
        {
            if (id != zonaComun.ZonaComunId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedZonaComun = await _zonaComunService.UpdateZonaComunAsync(id, zonaComun);

            if (updatedZonaComun is null)
                return NotFound(new { message = "Zona común no encontrada" });

            return Ok(updatedZonaComun);
        }

        // DELETE: api/ZonaComun/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteZonaComun(int id)
        {
            var success = await _zonaComunService.DeleteZonaComunAsync(id);

            if (!success)
                return NotFound(new { message = "Zona común no encontrada" });

            return NoContent();
        }
    }
}