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
    public class ConjuntoController : ControllerBase
    {
        private readonly IConjunto _conjuntoService;

        public ConjuntoController(IConjunto conjuntoService)
        {
            _conjuntoService = conjuntoService;
        }

        // GET: api/Conjunto
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Conjunto>>> GetConjunto()
        {
            var conjuntos = await _conjuntoService.GetConjuntoAsync();
            return Ok(conjuntos);
        }

        // GET: api/Conjunto/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ConjuntoCreateDTO>> GetConjuntoById(int id)
        {
            var conjunto = await _conjuntoService.GetConjuntoByIdAsync(id);

            if (conjunto is null)
                return NotFound(new { message = "Conjunto no encontrado" });

            var dto = new ConjuntoCreateDTO
            {
                ConjuntoId = conjunto.ConjuntoId,
                Nombre = conjunto.Nombre,
                Direccion = conjunto.Direccion,
                Ciudad = conjunto.Ciudad,
                NIT = conjunto.NIT,
                Telefono = conjunto.Telefono
            };

            return Ok(dto);
        }

        // POST: api/Conjunto
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(ConjuntoCreateDTO dto)
        {
            var conjunto = new Conjunto
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Ciudad = dto.Ciudad,
                NIT = dto.NIT,
                Telefono = dto.Telefono
            };

            await _conjuntoService.CreateConjuntoAsync(conjunto);

            return Ok(conjunto);
        }

        // PUT: api/Conjunto/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateConjunto(int id, ConjuntoCreateDTO dto)
        {
            var updatedConjunto = await _conjuntoService.UpdateConjuntoAsync(id, dto);

            if (updatedConjunto == null)
                return NotFound();

            return Ok(new
            {
                message = "Conjunto actualizado correctamente"
            });
        }

        // DELETE: api/Conjunto/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteConjunto(int id)
        {
            try
            {
                var success = await _conjuntoService.DeleteConjuntoAsync(id);
                if (!success)
                    return NotFound(new { message = "Conjunto no encontrado" });

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