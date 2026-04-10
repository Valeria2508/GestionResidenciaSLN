using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BitacoraVigilanciaController : ControllerBase
    {
        private readonly IBitacoraVigilancia _bitacoraVigilanciaService;

        public BitacoraVigilanciaController(IBitacoraVigilancia bitacoraVigilanciaService)
        {
            _bitacoraVigilanciaService = bitacoraVigilanciaService;
        }

        // GET: api/BitacoraVigilancia
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.BitacoraVigilancia>>> GetBitacoraVigilancia()
        {
            var bitacoraVigilancia = await _bitacoraVigilanciaService.GetBitacoraVigilanciaAsync();
            return Ok(bitacoraVigilancia);
        }

        // GET: api/BitacoraVigilancia por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.BitacoraVigilancia>> GetBitacoraVigilancia(int id)
        {
            var bitacoraVigilancia = await _bitacoraVigilanciaService.GetBitacoraVigilanciaByIdAsync(id);
            if (bitacoraVigilancia is null) return NotFound();
            return Ok(bitacoraVigilancia);
        }

        // POST: api/BitacoraVigilancia
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.BitacoraVigilancia>> CreateBitacoraVigilancia(GestionResidenciaApi.Models.BitacoraVigilancia bitacoraVigilancia)
        {
            var createdBitacoraVigilancia = await _bitacoraVigilanciaService.CreateBitacoraVigilanciaAsync(bitacoraVigilancia);
            return CreatedAtAction(nameof(GetBitacoraVigilancia), new { id = createdBitacoraVigilancia.BitacoraId }, createdBitacoraVigilancia);
        }

        // PUT: api/BitacoraVigilancia/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.BitacoraVigilancia>> UpdateBitacoraVigilancia(int id, GestionResidenciaApi.Models.BitacoraVigilancia bitacoraVigilancia)
        {
            var updatedBitacoraVigilancia = await _bitacoraVigilanciaService.UpdateBitacoraVigilanciaAsync(id, bitacoraVigilancia);
            if (updatedBitacoraVigilancia is null) return NotFound();
            return Ok(updatedBitacoraVigilancia);
        }

        // DELETE: api/BitacoraVigilancia/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.BitacoraVigilancia>> DeleteBitacoraVigilancia(int id)
        {
            var success = await _bitacoraVigilanciaService.DeleteBitacoraVigilanciaAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
