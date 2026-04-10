using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolPermisoController: ControllerBase
    {
        private readonly IRolPermiso _rolPermisoService;

        public RolPermisoController(IRolPermiso rolPermisoService)
        {
            _rolPermisoService = rolPermisoService;
        }

        // GET: api/RolPermiso
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.RolPermiso>>> GetRolPermisos()
        {
            var rolPermisos = await _rolPermisoService.GetRolPermisoAsync();
            return Ok(rolPermisos);
        }

        // GET: api/ApartaRolPermisomentos por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.RolPermiso>> GetRolPermiso(int id)
        {
            var rolPermiso = await _rolPermisoService.GetRolPermisoByIdAsync(id);
            if (rolPermiso is null) return NotFound();
            return Ok(rolPermiso);
        }

        // POST: api/Apartamentos
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.RolPermiso>> CreateRolPermiso(GestionResidenciaApi.Models.RolPermiso rolPermiso)
        {
            var createdRolPermiso = await _rolPermisoService.CreateRolPermisoAsync(rolPermiso);
            return CreatedAtAction(nameof(GetRolPermiso), new { id = createdRolPermiso.RolId }, createdRolPermiso);
        }

        // PUT: api/RolPermiso/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.RolPermiso>> UpdateRolPermiso(int id, GestionResidenciaApi.Models.RolPermiso rolPermiso)
        {
            var updatedRolPermiso = await _rolPermisoService.UpdateRolPermisoAsync(id, rolPermiso);
            if (updatedRolPermiso is null) return NotFound();
            return Ok(updatedRolPermiso);
        }

        // DELETE: api/RolPermiso/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.RolPermiso>> DeleteRolPermiso(int id)
        {
            var success = await _rolPermisoService.DeleteRolPermisoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
