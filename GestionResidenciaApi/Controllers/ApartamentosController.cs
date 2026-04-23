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
    public class ApartamentosController : ControllerBase
    {
        private readonly IApartamentos _apartamentosService;

        public ApartamentosController(IApartamentos apartamentosService)
        {
            _apartamentosService = apartamentosService;
        }

        // GET: api/Apartamentos
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Apartamentos>>> GetApartamentos()
        {
            var apartamentos = await _apartamentosService.GetApartamentosAsync();
            return Ok(apartamentos);
        }

        // GET: api/Apartamentos/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApartamentoCreateDTO>> GetApartamentoById(int id)
        {
            var apartamento = await _apartamentosService.GetApartamentoByIdAsync(id);

            if (apartamento is null)
                return NotFound(new { message = "Apartamento no encontrado" });

            var dto = new ApartamentoCreateDTO
            {
                UnidadId = apartamento.UnidadId,
                TorreId = apartamento.TorreId,
                Numero = apartamento.Numero,
                Tipo = apartamento.Tipo,
                Area = apartamento.Area
            };

            return Ok(dto);
        }

        // POST: api/Apartamentos
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateApartamento(ApartamentoCreateDTO dto)
        {
            var apartamento = new Apartamentos
            {
                TorreId = dto.TorreId,
                Numero = dto.Numero,
                Tipo = dto.Tipo,
                Area = dto.Area
            };

            await _apartamentosService.CreateApartamentoAsync(apartamento);

            return Ok(apartamento);
        }

        // PUT: api/Apartamentos/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Apartamentos>> UpdateApartamento(int id, [FromBody] Apartamentos apartamento)
        {
            if (id != apartamento.UnidadId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedApartamento = await _apartamentosService.UpdateApartamentoAsync(id, apartamento);

            if (updatedApartamento is null)
                return NotFound(new { message = "Apartamento no encontrado" });

            return Ok(updatedApartamento);
        }

        // DELETE: api/Apartamentos/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteApartamento(int id)
        {
            var success = await _apartamentosService.DeleteApartamentoAsync(id);

            if (!success)
                return NotFound(new { message = "Apartamento no encontrado" });

            return NoContent();
        }
    }
}