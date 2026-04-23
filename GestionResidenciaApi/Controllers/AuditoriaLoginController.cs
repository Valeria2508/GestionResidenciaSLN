using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
using GestionResidenciaApi.DTOs;

namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuditoriaLoginController : ControllerBase
    {
        private readonly IAuditoriaLogin _auditoriaLoginService;

        public AuditoriaLoginController(IAuditoriaLogin auditoriaLoginService)
        {
            _auditoriaLoginService = auditoriaLoginService;
        }

        // GET: api/AuditoriaLogin
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AuditoriaLogin>>> GetAuditoriaLogin()
        {
            var auditoriaLogin = await _auditoriaLoginService.GetAuditoriaLoginAsync();
            return Ok(auditoriaLogin);
        }

        // GET: api/AuditoriaLogin/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuditoriaLoginCreateDTO>> GetAuditoriaLoginById(int id)
        {
            var auditoriaLogin = await _auditoriaLoginService.GetAuditoriaLoginByIdAsync(id);

            if (auditoriaLogin is null)
                return NotFound(new { message = "AuditoriaLogin no encontrado" });

            var dto = new AuditoriaLoginCreateDTO
            {
                UsuarioId = auditoriaLogin.UsuarioId,
                Username = auditoriaLogin.Username,
                FechaIntento = auditoriaLogin.FechaIntento,
                Ip = auditoriaLogin.Ip,
                Exitoso = auditoriaLogin.Exitoso,
                Motivo = auditoriaLogin.Motivo
            };

            return Ok(dto);
        }

        // POST: api/AuditoriaLogin
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> CreateAuditoriaLogin([FromBody] AuditoriaLoginCreateDTO dto)
        {
            var auditoriaLogin = new AuditoriaLogin
            {
                UsuarioId = dto.UsuarioId,
                Username = dto.Username,
                FechaIntento = dto.FechaIntento,
                Ip = dto.Ip,
                Exitoso = dto.Exitoso,
                Motivo = dto.Motivo
            };

            await _auditoriaLoginService.CreateAuditoriaLoginAsync(auditoriaLogin);

            return Ok(auditoriaLogin);
        }

        // PUT: api/AuditoriaLogin/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuditoriaLogin>> UpdateAuditoriaLogin(int id, [FromBody] AuditoriaLogin auditoriaLogin)
        {
            if (id != auditoriaLogin.UsuarioId)
                return BadRequest(new { message = "El Usarname no coincide" });

            var updatedAuditoriaLogin = await _auditoriaLoginService.UpdateAuditoriaLoginAsync(id, auditoriaLogin);

            if (updatedAuditoriaLogin is null)
                return NotFound(new { message = "AuditoriaLogin no encontrado" });

            return Ok(updatedAuditoriaLogin);
        }

        // DELETE: api/AuditoriaLogin/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAuditoriaLogin(int id)
        {
            var success = await _auditoriaLoginService.DeleteAuditoriaLoginAsync(id);

            if (!success)
                return NotFound(new { message = "AuditoriaLogin no encontrado" });

            return NoContent();
        }
    }
}