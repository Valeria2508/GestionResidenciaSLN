using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PermisoController : ControllerBase
    {
        private readonly IPermiso _permisoService;

        public PermisoController(IPermiso permisoService)
        {
            _permisoService = permisoService;
        }

        // GET: api/Permiso
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Permiso>>> GetPermiso()
        {
            var permiso = await _permisoService.GetPermisoAsync();
            return Ok(permiso);
        }

        // GET: api/Conjunto/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PermisoDTO>> GetPermisoById(int id)
        {
            var permiso = await _permisoService.GetPermisoByIdAsync(id);

            if (permiso is null)
                return NotFound(new { message = "Permiso no encontrado" });

            var dto = new PermisoDTO
            {
                PermisoId = permiso.PermisoId,
                Nombre = permiso.Nombre
            };

            return Ok(dto);
        }


        // POST: api/Permiso
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(PermisoDTO dto)
        {
            var permiso = new Permiso
            {
                PermisoId = dto.PermisoId,
                Nombre = dto.Nombre
            };

            await _permisoService.CreatePermisoAsync(permiso);

            return Ok(permiso);
        }
        // PUT: api/Permiso/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePermiso(int id, PermisoDTO dto)
        {
            var updatedPermiso = await _permisoService.UpdatePermisoAsync(id, dto);

            if (updatedPermiso == null)
                return NotFound();

            return Ok(new
            {
                message = "Permiso actualizado correctamente"
            });
        }

        // DELETE: api/Permiso/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            try
            {
                var success = await _permisoService.DeletePermisoAsync(id);
                if (!success)
                    return NotFound(new { message = "Permiso no encontrado" });

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