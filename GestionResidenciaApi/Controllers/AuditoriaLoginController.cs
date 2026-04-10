using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaLoginController : ControllerBase
    {
        private readonly IAuditoriaLogin _auditoriaLoginService;

        public AuditoriaLoginController(IAuditoriaLogin _auditoriaLoginService)
        {
            _auditoriaLoginService = _auditoriaLoginService;
        }

        // GET: api/AuuditoriaLogin
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.AuditoriaLogin>>> GetAuditoriaLogin()
        {
            var auditoriaLogin = await _auditoriaLoginService.GetAuditoriaLoginAsync();
            return Ok(auditoriaLogin);
        }

        // GET: api/AuditoriaLogin por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.AuditoriaLogin>> GetauditoriaLogin(int id)
        {
            var auditoriaLogin = await _auditoriaLoginService.GetAuditoriaLoginByIdAsync(id);
            if (auditoriaLogin is null) return NotFound();
            return Ok(auditoriaLogin);
        }

        // POST: api/AuditoriaLogin
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.AuditoriaLogin>> CreateAuditoriaLogin(GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin)
        {
            var createdAuditoriaLogin = await _auditoriaLoginService.CreateAuditoriaLoginAsync(auditoriaLogin);
            return CreatedAtAction(nameof(GetAuditoriaLogin), new { id = createdAuditoriaLogin.AuditoriaId }, createdAuditoriaLogin);
        }

        // PUT: api/Apartamentos/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.AuditoriaLogin>> UpdateAuditoriaLogin(int id, GestionResidenciaApi.Models.AuditoriaLogin auditoriaLogin)
        {
            var updatedAuditoriaLogin = await _auditoriaLoginService.UpdateAuditoriaLoginAsync(id, auditoriaLogin);
            if (updatedAuditoriaLogin is null) return NotFound();
            return Ok(updatedAuditoriaLogin);
        }

        // DELETE: api/Apartamentos/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.AuditoriaLogin>> DeleteAuditoriaLogin(int id)
        {
            var success = await _auditoriaLoginService.DeleteAuditoriaLoginAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
