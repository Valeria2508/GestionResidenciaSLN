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
    public class RolPermisoController : ControllerBase
    {
        private readonly IRolPermiso _rolPermisoService;

        public RolPermisoController(IRolPermiso rolPermisoService)
        {
            _rolPermisoService = rolPermisoService;
        }

        // GET: api/RolPermiso
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RolPermiso>>> GetRolPermiso()
        {
            var rolPermiso = await _rolPermisoService.GetRolPermisoAsync();
            return Ok(rolPermiso);
        }

        // GET: api/RolPermiso/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolPermisoDTO>> GetRolPermisoById(int id)
        {
            var rolPermiso = await _rolPermisoService.GetRolPermisoByIdAsync(id);

            if (rolPermiso is null)
                return NotFound(new { message = "RolPermiso no encontrado" });

            var dto = new RolPermisoDTO
            {
                RolId = rolPermiso.RolId,
                PermisoId = rolPermiso.PermisoId
            };

            return Ok(dto);
        }

        // POST: api/RolPermiso
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RolPermisoDTO dto)
        {
            var rolPermiso = new RolPermiso
            {
                RolId = dto.RolId,
                PermisoId = dto.PermisoId
            };

            await _rolPermisoService.CreateRolPermisoAsync(rolPermiso);
            return Ok(rolPermiso);
        }

        // PUT: api/RolPermiso/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RolPermiso>> UpdateRolPermiso(int id, [FromBody] RolPermiso rolPermiso)
        {
            if (id != rolPermiso.RolId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedRolPermiso = await _rolPermisoService.UpdateRolPermisoAsync(id, rolPermiso);

            if (updatedRolPermiso is null)
                return NotFound(new { message = "RolPermiso no encontrado" });

            return Ok(updatedRolPermiso);
        }

        // DELETE: api/RolPermiso/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRolPermiso(int id)
        {
            var success = await _rolPermisoService.DeleteRolPermisoAsync(id);

            if (!success)
                return NotFound(new { message = "RolPermiso no encontrado" });

            return NoContent();
        }
    }
}