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
    public class RolController : ControllerBase
    {
        private readonly IRol _rolService;

        public RolController(IRol rolService)
        {
            _rolService = rolService;
        }

        // GET: api/rol
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
        {
            var rol = await _rolService.GetRolAsync();
            return Ok(rol);
        }

        // GET: api/rol/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolDTO>> GetRolById(int id)
        {
            var rol = await _rolService.GetRolByIdAsync(id);

            if (rol is null)
                return NotFound(new { message = "Rol no encontrado" });

            var dto = new RolDTO
            {
                RolId = rol.RolId
            };

            return Ok(dto);
        }

        // POST: api/rol
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] RolDTO dto)
        {
            var rol = new Rol
            {
                Nombre = dto.Nombre
            };

            await _rolService.CreateRolAsync(rol);
            return Ok(rol);
        }

        // PUT: api/Rol/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Rol>> UpdateRol(int id, [FromBody] Rol rol)
        {
            if (id != rol.RolId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedRol = await _rolService.UpdateRolAsync(id, rol);

            if (updatedRol is null)
                return NotFound(new { message = "Rol no encontrado" });

            return Ok(updatedRol);
        }

        // DELETE: api/Rol/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var success = await _rolService.DeleteRolAsync(id);

            if (!success)
                return NotFound(new { message = "Rol no encontrado" });

            return NoContent();
        }
    }
}