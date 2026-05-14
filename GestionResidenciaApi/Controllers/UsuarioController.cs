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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuario _usuarioService;

        public UsuarioController(IUsuario usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // GET: api/Usuarios
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetUsuarioAsync();
            return Ok(usuarios);
        }

        // GET: api/Usuario/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UsuarioCreateDTO>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);

            if (usuario is null)
                return NotFound(new { message = "Usuario no encontrado" });

            var dto = new UsuarioCreateDTO
            {
                UsuarioId = usuario.UsuarioId,
                RolId = usuario.RolId,
                PersonaId = usuario.PersonaId,
                Username = usuario.Username,
                PasswordHash = usuario.PasswordHash,
                Activo = usuario.Activo,
                FechaCreacion = usuario.FechaCreacion
            };

            return Ok(dto);
        }

        // POST: api/Usuarios
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(UsuarioCreateDTO dto)
        {
            var usuario = new Usuario
            {
                // Do not set UsuarioId when creating a new entity - it's an IDENTITY/primary key
                RolId = dto.RolId,
                PersonaId = dto.PersonaId,
                Username = dto.Username,
                PasswordHash = dto.PasswordHash,
                Activo = dto.Activo,
                FechaCreacion = dto.FechaCreacion
            };

            await _usuarioService.CreateUsuarioAsync(usuario);

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUsuario(int id, UsuarioCreateDTO dto)
        {
            var updatedUsuario = await _usuarioService.UpdateUsuarioAsync(id, dto);

            if (updatedUsuario == null)
                return NotFound();

            return Ok(new
            {
                message = "Usuario actualizado correctamente"
            });
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                var success = await _usuarioService.DeleteUsuarioAsync(id);
                if (!success)
                    return NotFound(new { message = "Usuario no encontrado" });

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