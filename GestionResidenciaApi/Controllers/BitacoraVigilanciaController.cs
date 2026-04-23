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
    public class BitacoraVigilanciaController : ControllerBase
    {
        private readonly IBitacoraVigilancia _bitacoraVigilanciaService;

        public BitacoraVigilanciaController(IBitacoraVigilancia bitacoraVigilanciaService)
        {
            _bitacoraVigilanciaService = bitacoraVigilanciaService;
        }

        // GET: api/BitacoraVigilancia
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BitacoraVigilancia>>> GetBitacoraVigilancia()
        {
            var bitacoraVigilancia = await _bitacoraVigilanciaService.GetBitacoraVigilanciaAsync();
            return Ok(bitacoraVigilancia);
        }

        // GET: api/BitacoraVigilancia/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BitacoraVigilanciaDTO>> GetBitacoraVigilanciaById(int id)
        {
            var bitacoraVigilancia = await _bitacoraVigilanciaService.GetBitacoraVigilanciaByIdAsync(id);

            if (bitacoraVigilancia is null)
                return NotFound(new { message = "BitacoraVigilancia no encontrado" });

            var dto = new BitacoraVigilanciaDTO
            {
                VigilanteId = bitacoraVigilancia.VigilanteId,
                TipoEventoId = bitacoraVigilancia.TipoEventoId,
                IngresoId = bitacoraVigilancia.IngresoId,
                UnidadId = bitacoraVigilancia.UnidadId
            };

            return Ok(dto);
        }

        // POST: api/BitacoraVigilancia
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(BitacoraVigilanciaDTO dto)
        {
            var bitacora = new BitacoraVigilancia
            {
                VigilanteId = dto.VigilanteId,
                TipoEventoId = dto.TipoEventoId,
                IngresoId = dto.IngresoId,
                UnidadId = dto.UnidadId,
                FechaHora = dto.FechaHora,
                Observacion = dto.Observacion
            };

            await _bitacoraVigilanciaService.CreateBitacoraVigilanciaAsync(bitacora);

            return Ok(bitacora);
        }

        // PUT: api/BitacoraVigilancia/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BitacoraVigilancia>> UpdateBitacoraVigilancia(int id, [FromBody] BitacoraVigilancia bitacoraVigilancia)
        {
            if (id != bitacoraVigilancia.UnidadId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedBitacoraVigilancia = await _bitacoraVigilanciaService.UpdateBitacoraVigilanciaAsync(id, bitacoraVigilancia);

            if (updatedBitacoraVigilancia is null)
                return NotFound(new { message = "BitacoraVigilancia no encontrado" });

            return Ok(updatedBitacoraVigilancia);
        }

        // DELETE: api/Apartamentos/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBitacoraVigilancia(int id)
        {
            var success = await _bitacoraVigilanciaService.DeleteBitacoraVigilanciaAsync(id);

            if (!success)
                return NotFound(new { message = "BitacoraVigilancia no encontrado" });

            return NoContent();
        }
    }
}