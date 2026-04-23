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
    public class ParqueaderoVisitanteController : ControllerBase
    {
        private readonly IParqueaderoVisitante _parqueaderoVisitanteService;

        public ParqueaderoVisitanteController(IParqueaderoVisitante parqueaderoVisitanteService)
        {
            _parqueaderoVisitanteService = parqueaderoVisitanteService;
        }

        // GET: api/ParqueaderoVisitante
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ParqueaderoVisitante>>> GetParqueaderoVisitante()
        {
            var parqueaderoVisitante = await _parqueaderoVisitanteService.GetParqueaderoVisitanteAsync();
            return Ok(parqueaderoVisitante);
        }

        // GET: api/ParqueaderoVisitante/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ParqueaderoVisitanteDTO>> GetParqueaderoVisitanteById(int id)
        {
            var parqueaderoVisitante = await _parqueaderoVisitanteService.GetParqueaderoVisitanteByIdAsync(id);

            if (parqueaderoVisitante is null)
                return NotFound(new { message = "ParqueaderoVisitante no encontrado" });

            var dto = new ParqueaderoVisitanteDTO
            {
                ParqueaderoId = parqueaderoVisitante.ParqueaderoId,
                IngresoId = parqueaderoVisitante.IngresoId
            };

            return Ok(dto);
        }

        // POST: api/ParqueaderoVisitante
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(ParqueaderoVisitanteDTO dto)
        {
            var parqueaderoVisitante = new ParqueaderoVisitante
            {
                ParqueaderoId = dto.ParqueaderoId,
                IngresoId = dto.IngresoId,
                Placa = dto.Placa,
                FechaHoraIngreso = dto.FechaHoraIngreso,
                FechaHoraSalida = dto.FechaHoraSalida
            };

            await _parqueaderoVisitanteService.CreateParqueaderoVisitanteAsync(parqueaderoVisitante);

            return Ok(parqueaderoVisitante);
        }

        // PUT: api/ParqueaderoVisitante/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ParqueaderoVisitante>> UpdateParqueaderoVisitante(int id, [FromBody] ParqueaderoVisitante parqueaderoVisitante)
        {
            if (id != parqueaderoVisitante.ParqueaderoVisitanteId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedParqueaderoVisitante = await _parqueaderoVisitanteService.UpdateParqueaderoVisitanteAsync(id, parqueaderoVisitante);

            if (updatedParqueaderoVisitante is null)
                return NotFound(new { message = "ParqueaderoVisitante no encontrado" });

            return Ok(updatedParqueaderoVisitante);
        }

        // DELETE: api/ParqueaderoVisitante/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteParqueaderoVisitante(int id)
        {
            var success = await _parqueaderoVisitanteService.DeleteParqueaderoVisitanteAsync(id);

            if (!success)
                return NotFound(new { message = "ParqueaderoVisitante no encontrado" });

            return NoContent();
        }
    }
}