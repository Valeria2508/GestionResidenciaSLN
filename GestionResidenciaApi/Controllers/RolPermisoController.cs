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

        // GET: api/RolPermiso/{rolId}/{permisoId}
        [HttpGet("{rolId:int}/{permisoId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RolPermisoDTO>> GetRolPermisoById(int rolId, int permisoId)
        {
            var rolPermiso = await _rolPermisoService.GetRolPermisoByIdAsync(rolId, permisoId);

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
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(RolPermisoDTO dto)
        {
            var rolPermiso = new RolPermiso
            {
                RolId = dto.RolId,
                PermisoId = dto.PermisoId
            };

            await _rolPermisoService.CreateRolPermisoAsync(rolPermiso);

            return Ok(rolPermiso);
        }

        // PUT: api/RolPermiso/{rolId}/{permisoId}
        [HttpPut("{rolId:int}/{permisoId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateRolPermiso(int rolId, int permisoId, RolPermisoDTO dto)
        {
            var updatedRolPermiso = await _rolPermisoService.UpdateRolPermisoAsync(rolId, permisoId, dto);

            if (updatedRolPermiso == null)
                return NotFound();

            return Ok(new
            {
                message = "RolPermiso actualizado correctamente"
            });
        }

        // DELETE: api/RolPermiso/{rolId}/{permisoId}
        [HttpDelete("{rolId:int}/{permisoId:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRolPermiso(int rolId, int permisoId)
        {
            try
            {
                var success = await _rolPermisoService.DeleteRolPermisoAsync(rolId, permisoId);
                if (!success)
                    return NotFound(new { message = "RolPermiso no encontrado" });

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