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
    public class MetodoPagoController : ControllerBase
    {
        private readonly IMetodoPago _metodoPagoService;

        public MetodoPagoController(IMetodoPago metodoPagoService)
        {
            _metodoPagoService = metodoPagoService;
        }

        // GET: api/MetodoPago
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MetodoPago>>> GetMetodosPago()
        {
            var metodosPago = await _metodoPagoService.GetMetodoPagoAsync();
            return Ok(metodosPago);
        }

        // GET: api/MetodoPag/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MetodoPagoDTO>> GetMetodoPagoById(int id)
        {
            var metodoPago = await _metodoPagoService.GetMetodoPagoByIdAsync(id);

            if (metodoPago is null)
                return NotFound(new { message = "Metodo de pago no encontrado" });

            var dto = new MetodoPagoDTO
            {
                MetodoPagoId = metodoPago.MetodoPagoId
            };

            return Ok(dto);
        }

        // POST: api/MetodoPago
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(MetodoPagoDTO dto)
        {
            var metodoPago = new MetodoPago
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            await _metodoPagoService.CreateMetodoPagoAsync(metodoPago);

            return Ok(metodoPago);
        }

        // PUT: api/MetodoPago/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MetodoPago>> UpdateMetodoPago(int id, [FromBody] MetodoPago metodoPago)
        {
            if (id != metodoPago.MetodoPagoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedMetodoPago = await _metodoPagoService.UpdateMetodoPagoAsync(id, metodoPago);

            if (updatedMetodoPago is null)
                return NotFound(new { message = "Metodo de pago no encontrado" });

            return Ok(updatedMetodoPago);
        }

        // DELETE: api/MetodoPago/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMetodoPago(int id)
        {
            var success = await _metodoPagoService.DeleteMetodoPagoAsync(id);

            if (!success)
                return NotFound(new { message = "Metodo de pago no encontrado" });

            return NoContent();
        }
    }
}