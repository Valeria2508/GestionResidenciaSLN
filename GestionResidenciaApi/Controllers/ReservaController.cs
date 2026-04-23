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
    public class ReservaController : ControllerBase
    {
        private readonly IReserva _reservaService;

        public ReservaController(IReserva reservaService)
        {
            _reservaService = reservaService;
        }

        // GET: api/Reserva
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
        {
            var reserva = await _reservaService.GetReservaAsync();
            return Ok(reserva);
        }

        // GET: api/Reserva/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReservaDTO>> GetReservaById(int id)
        {
            var reserva = await _reservaService.GetReservaByIdAsync(id);

            if (reserva is null)
                return NotFound(new { message = "Reserva no encontrada" });

            var dto = new ReservaDTO
            {
                ZonaComunId = reserva.ZonaComunId,
                UsuarioId = reserva.UsuarioId,
                EstadoId = reserva.EstadoId
            };

            return Ok(dto);
        }

        // POST: api/Reserva
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] ReservaDTO dto)
        {
            var reserva = new Reserva
            {
                ZonaComunId = dto.ZonaComunId,
                UsuarioId = dto.UsuarioId,
                EstadoId = dto.EstadoId,
                Fecha = dto.Fecha,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                Observacion = dto.Observaciones
            };

            await _reservaService.CreateReservaAsync(reserva);
            return Ok(reserva);
        }

        // PUT: api/Reserva/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Reserva>> UpdateReserva(int id, [FromBody] Reserva reserva)
        {
            if (id != reserva.ZonaComunId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedReserva = await _reservaService.UpdateReservaAsync(id, reserva);

            if (updatedReserva is null)
                return NotFound(new { message = "Reserva no encontrada" });

            return Ok(updatedReserva);
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteReserva(int id)
        {
            var success = await _reservaService.DeleteReservaAsync(id);

            if (!success)
                return NotFound(new { message = "Reserva no encontrada" });

            return NoContent();
        }
    }
}