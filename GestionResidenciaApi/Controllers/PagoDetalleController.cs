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
    public class PagoDetalleController : ControllerBase
    {
        private readonly IPagoDetalle _pagoDetalleService;

        public PagoDetalleController(IPagoDetalle pagoDetalleService)
        {
            _pagoDetalleService = pagoDetalleService;
        }

        // GET: api/PagoDetalle
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PagoDetalle>>> GetPagoDetalle()
        {
            var pagoDetalles = await _pagoDetalleService.GetPagoDetallesAsync();
            return Ok(pagoDetalles);
        }

        // GET: api/PagoDetalle/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagoDetalleDTO>> GetPagoDetalleById(int id)
        {
            var pagoDetalle = await _pagoDetalleService.GetPagoDetalleByIdAsync(id);

            if (pagoDetalle is null)
                return NotFound(new { message = "PagoDetalle no encontrado" });

            var dto = new PagoDetalleDTO
            {
                CuotaId = pagoDetalle.CuotaId,
                PagoId = pagoDetalle.PagoId,
                ValorAbonado = pagoDetalle.ValorAbonado
            };

            return Ok(dto);
        }

        // POST: api/PagoDetalle
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(PagoDetalleDTO dto)
        {
            try
            {
                var pagoDetalle = new PagoDetalle
                {
                    CuotaId = dto.CuotaId,
                    PagoId = dto.PagoId,
                    ValorAbonado = dto.ValorAbonado
                };

                await _pagoDetalleService.CreatePagoDetalleAsync(pagoDetalle);

                return Ok(new
                {
                    message = "Pago detalle creado correctamente"
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

        // PUT: api/PagoDetalle/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePagoDetalle(int id, PagoDetalleDTO dto)
        {
            var updatedPagoDetalle = await _pagoDetalleService.UpdatePagoDetalleAsync(id, dto);

            if (updatedPagoDetalle == null)
                return NotFound();

            return Ok(new
            {
                message = "PagoDetalle actualizado correctamente"
            });
        }

        // DELETE: api/PagoDetalle/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePagoDetalle(int id)
        {
            try
            {
                var success = await _pagoDetalleService.DeletePagoDetalleAsync(id);
                if (!success)
                    return NotFound(new { message = "PagoDetalle no encontrado" });

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