using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly IPermiso _permisoService;

        public PermisoController(IPermiso permisoService)
        {
            _permisoService = permisoService;
        }

        // GET: api/Permiso
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Permiso>>> GetPermisos   ()
        {
            var permisos = await _permisoService.GetPermisoAsync();
            return Ok(permisos);
        }

        // GET: api/Permiso por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Permiso>> GetPermiso(int id)
        {
            var permiso = await _permisoService.GetPermisoByIdAsync(id);
            if (permiso is null) return NotFound();
            return Ok(permiso);
        }

        // POST: api/Permiso
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Permiso>> CreatePermiso(GestionResidenciaApi.Models.Permiso permiso)
        {
            var createdPermiso = await _permisoService.CreatePermisoAsync(permiso);
            return CreatedAtAction(nameof(GetPermiso), new { id = createdPermiso.PermisoId }, createdPermiso);
        }

        // PUT: api/Permiso/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Permiso>> UpdatePermiso(int id, GestionResidenciaApi.Models.Permiso permiso)
        {
            var updatedPermiso = await _permisoService.UpdatePermisoAsync(id, permiso);
            if (updatedPermiso is null) return NotFound();
            return Ok(updatedPermiso);
        }

        // DELETE: api/Permiso/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Permiso>> DeletePermiso(int id)
        {
            var success = await _permisoService.DeletePermisoAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
