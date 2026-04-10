using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeriaController : ControllerBase
    {
        private readonly IMensajeria _mensajeriaService;

        public MensajeriaController(IMensajeria mensajeriaService)
        {
            _mensajeriaService = mensajeriaService;
        }

        // GET: api/Mensajeria
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Mensajeria>>> GetMensajeria()
        {
            var mensajeria = await _mensajeriaService.GetMensajeriaAsync();
            return Ok(mensajeria);
        }

        // GET: api/Mensajeria por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mensajeria>> GetMensajeria(int id)
        {
            var mensaje = await _mensajeriaService.GetMensajeriaByIdAsync(id);
            if (mensaje is null) return NotFound();
            return Ok(mensaje);
        }

        // POST: api/Mensajeria
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mensajeria>> CreateMensajeria(GestionResidenciaApi.Models.Mensajeria mensajeria)
        {
            var createdMensajeria = await _mensajeriaService.CreateMensajeriaAsync(mensajeria);
            return CreatedAtAction(nameof(GetMensajeria), new { id = createdMensajeria.MensajeriaId }, createdMensajeria);
        }

        // PUT: api/Mensajeria/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mensajeria>> UpdateMensajeria(int id, GestionResidenciaApi.Models.Mensajeria mensajeria)
        {
            var updatedMensajeria = await _mensajeriaService.UpdateMensajeriaAsync(id, mensajeria);
            if (updatedMensajeria is null) return NotFound();
            return Ok(updatedMensajeria);
        }

        // DELETE: api/Mensajeria/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Mensajeria>> DeleteMensajeria(int id)
        {
            var success = await _mensajeriaService.DeleteMensajeriaAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
