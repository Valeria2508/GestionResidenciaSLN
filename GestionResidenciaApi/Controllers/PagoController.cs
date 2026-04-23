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
    public class PagoController : ControllerBase
    {
        private readonly IPago _pagoService;

        public PagoController(IPago pagoService)
        {
            _pagoService = pagoService;
        }

        // GET: api/pago
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Pago>>> GetPago()
        {
            var pagos = await _pagoService.GetPagoAsync();
            return Ok(pagos);
        }

        // GET: api/pago/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagoCreateDTO>> GetPagoById(int id)
        {
            var pago = await _pagoService.GetPagoByIdAsync(id);

            if (pago is null)
                return NotFound(new { message = "Pago no encontrado" });

            var dto = new PagoCreateDTO
            {
                UsuarioId = pago.UsuarioId,
                MetodoPagoId = pago.MetodoPagoId
            };

            return Ok(dto);
        }

        // POST: api/pago
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(PagoCreateDTO dto)
        {
            var pago = new Pago
            {
                UsuarioId = dto.UsuarioId,
                MetodoPagoId = dto.MetodoPagoId,
                FechaPago = dto.FechaPago,
                ValorTotal = dto.ValorTotal,
                Referencia = dto.Referencia,
                PagoObservacionId = dto.PagoObservacionId
            };

            await _pagoService.CreatePagoAsync(pago);

            return Ok(pago);
        }

        // PUT: api/pago/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pago>> UpdatePago(int id, [FromBody] Pago pago)
        {
            if (id != pago.MetodoPagoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedPago = await _pagoService.UpdatePagoAsync(id, pago);

            if (updatedPago is null)
                return NotFound(new { message = "Pago no encontrado" });

            return Ok(updatedPago);
        }

        // DELETE: api/pago/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePago(int id)
        {
            var success = await _pagoService.DeletePagoAsync(id);

            if (!success)
                return NotFound(new { message = "Pago no encontrado" });

            return NoContent();
        }
    }
}