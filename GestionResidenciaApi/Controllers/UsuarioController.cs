using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioService;

        public UsuarioController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetUsuarioAsync();
            return Ok(usuarios);
        }

        // GET: api/Usuarios por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Usuario>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario is null) return NotFound();
            return Ok(usuario);
        }

        // POST: api/Usuarios
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Usuario>> CreateUsuario(GestionResidenciaApi.Models.Usuario usuario)
        {
            var createdUsuario = await _usuarioService.CreateUsuarioAsync(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.UsuarioId }, createdUsuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Usuario>> UpdateUsuario(int id, GestionResidenciaApi.Models.Usuario usuario)
        {
            var updatedUsuario = await _usuarioService.UpdateUsuarioAsync(id, usuario);
            if (updatedUsuario is null) return NotFound();
            return Ok(updatedUsuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Usuario>> DeleteUsuario(int id)
        {
            var success = await _usuarioService.DeleteUsuarioAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
