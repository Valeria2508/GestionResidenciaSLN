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

        // GET: api/Permiso/5
        //[HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<PermiaoD>> GetApartamentoById(int id)
        //{
        //    var apartamento = await _apartamentosService.GetApartamentoByIdAsync(id);

        //    if (apartamento is null)
        //        return NotFound(new { message = "Apartamento no encontrado" });

        //    var dto = new ApartamentoResponseDTO
        //    {
        //        UnidadId = apartamento.UnidadId,
        //        TorreId = apartamento.TorreId,
        //        Numero = apartamento.Numero,
        //        Tipo = apartamento.Tipo,
        //        Area = apartamento.Area
        //    };

        //    return Ok(dto);
        //}

        // POST: api/Permiso
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreatePermiso(PermisoDTO dto)
        {
            var permiso = new Permiso
            {
                Nombre = dto.Nombre,
            };

            await _permisoService.CreatePermisoAsync(permiso);

            return Ok(permiso);
        }

        // PUT: api/Permiso/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Permiso>> UpdatePermiso(int id, [FromBody] Permiso permiso)
        {
            if (id != permiso.PermisoId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedPermiso = await _permisoService.UpdatePermisoAsync(id, permiso);

            if (updatedPermiso is null)
                return NotFound(new { message = "Permiso no encontrado" });

            return Ok(updatedPermiso);
        }

        // DELETE: api/Permiso/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePermiso(int id)
        {
            var success = await _permisoService.DeletePermisoAsync(id);

            if (!success)
                return NotFound(new { message = "Permiso no encontrado" });

            return NoContent();
        }
    }
}