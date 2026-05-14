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
                Nombre = metodoPago.Nombre,
                Descripcion = metodoPago.Descripcion
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
        public async Task<IActionResult> UpdateMetodoPago(int id, MetodoPagoDTO dto)
        {
            var updatedMetodoPago = await _metodoPagoService.UpdateMetodoPagoAsync(id, dto);

            if (updatedMetodoPago == null)
                return NotFound();

            return Ok(new
            {
                message = "Metodo de pago actualizado correctamente"
            });
        }

        // DELETE: api/MetodoPago/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMetodoPago(int id)
        {
            try
            {
                var success = await _metodoPagoService.DeleteMetodoPagoAsync(id);
                if (!success)
                    return NotFound(new { message = "Metodo de pago no encontrado" });

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