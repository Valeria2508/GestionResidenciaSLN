using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IRol _rolService;

        public RolController(IRol rolService)
        {
            _rolService = rolService;
        }

        // GET: api/Rol
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Rol>>> GetRoles()
        {
            var roles = await _rolService.GetRolAsync();
            return Ok(roles);
        }

        // GET: api/Rol por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Rol>> GetRol(int id)
        {
            var rol = await _rolService.GetRolByIdAsync(id);
            if (rol is null) return NotFound();
            return Ok(rol);
        }

        // POST: api/Rol
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Rol>> CreateRol(GestionResidenciaApi.Models.Rol rol)
        {
            var createdRol = await _rolService.CreateRolAsync(rol);
            return CreatedAtAction(nameof(GetRol), new { id = createdRol.RolId }, createdRol);
        }

        // PUT: api/Rol/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Rol>> UpdateRol(int id, GestionResidenciaApi.Models.Rol rol)
        {
            var updatedRol = await _rolService.UpdateRolAsync(id, rol);
            if (updatedRol is null) return NotFound();
            return Ok(updatedRol);
        }

        // DELETE: api/Rol/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Rol>> DeleteRol(int id)
        {
            var success = await _rolService.DeleteRolAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
