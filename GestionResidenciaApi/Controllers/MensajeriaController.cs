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
    public class MensajeriaController : ControllerBase
    {
        private readonly IMensajeria _mensajeriaService;

        public MensajeriaController(IMensajeria mensajeriaService)
        {
            _mensajeriaService = mensajeriaService;
        }

        // GET: api/Mensajeria
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Mensajeria>>> GetMensajeria()
        {
            var mensajeria = await _mensajeriaService.GetMensajeriaAsync();
            return Ok(mensajeria);
        }

        // GET: api/Mensajeria/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MensajeriaDTO>> GetMensajeriaById(int id)
        {
            var mensajeria = await _mensajeriaService.GetMensajeriaByIdAsync(id);

            if (mensajeria is null)
                return NotFound(new { message = "Mensajeria no encontrada" });

            var dto = new MensajeriaDTO
            {
                UnidadId = mensajeria.UnidadId,
                UsuarioId = mensajeria.UsuarioId,
                Empresa = mensajeria.Empresa,
                Guia = mensajeria.Guia,
                Descripcion = mensajeria.Descripcion,
                FechaRecepcion = mensajeria.FechaRecepcion,
                FechaEntrega = mensajeria.FechaEntrega
            };
            return Ok(dto);
        }

        // POST: api/Mensajeria
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(MensajeriaDTO dto)
        {
            var mensajeria = new Mensajeria
            {
                UnidadId = dto.UnidadId,
                UsuarioId = dto.UsuarioId,
                Empresa = dto.Empresa,
                Guia = dto.Guia,
                Descripcion = dto.Descripcion,
                FechaRecepcion = dto.FechaRecepcion,
                FechaEntrega = dto.FechaEntrega
            };

            await _mensajeriaService.CreateMensajeriaAsync(mensajeria);

            return Ok(mensajeria);
        }

        // PUT: api/Mensajeria/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateMensajeria(int id, MensajeriaDTO dto)
        {
            var updatedMensajeria = await _mensajeriaService.UpdateMensajeriaAsync(id, dto);

            if (updatedMensajeria == null)
                return NotFound();

            return Ok(new
            {
                message = "Mensajeria actualizada correctamente"
            });
        }

        // DELETE: api/Mensajeria/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMensajeria(int id)
        {
            try
            {
                var success = await _mensajeriaService.DeleteMensajeriaAsync(id);
                if (!success)
                    return NotFound(new { message = "Mensajeria no encontrada" });

                return Ok(new
                {
                    message = "Mensajeria eliminada correctamente"
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