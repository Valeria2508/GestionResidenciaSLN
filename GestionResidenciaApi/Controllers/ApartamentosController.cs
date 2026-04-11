using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartamentosController : ControllerBase
    {
        private readonly IApartamentos _apartamentosService;

        public ApartamentosController(IApartamentos apartamentosService)
        {
            _apartamentosService = apartamentosService;
        }

        // GET: api/Apartamentos
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Apartamentos>>> GetApartamentos()
        {
            var apartamentos = await _apartamentosService.GetApartamentosAsync();
            return Ok(apartamentos);
        }
 
        // GET: api/Apartamentos por id/
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Apartamentos>>GetApartamentos(int id)
        {
            var apartamento = await _apartamentosService.GetApartamentoByIdAsync(id);
            if (apartamento is null) return NotFound();
            return Ok(apartamento);
        }

        // POST: api/Apartamentos
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Apartamentos>> CreateApartamento(GestionResidenciaApi.Models.Apartamentos apartamento)
        {
            var createdApartamento = await _apartamentosService.CreateApartamentoAsync(apartamento);
            return CreatedAtAction(nameof(GetApartamentos), new { id = createdApartamento.UnidadId }, createdApartamento);
        }

        // PUT: api/Apartamentos/5
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Apartamentos>> UpdateApartamento(int id, GestionResidenciaApi.Models.Apartamentos apartamento)
        {
            var updatedApartamento = await _apartamentosService.UpdateApartamentoAsync(id, apartamento);
            if (updatedApartamento is null) return NotFound();
            return Ok(updatedApartamento);
        }

        // DELETE: api/Apartamentos/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Apartamentos>> DeleteApartamento(int id)
        {
            var success = await _apartamentosService.DeleteApartamentoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
