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
    public class VisitanteController : ControllerBase
    {
        private readonly IVisitante _visitanteService;

        public VisitanteController(IVisitante visitanteService)
        {
            _visitanteService = visitanteService;
        }

        // GET: api/Visitante
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Visitante>>> GetVisitantes()
        {
            var visitantes = await _visitanteService.GetVisitanteAsync();
            return Ok(visitantes);
        }

        // GET: api/Visitante/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VisitanteDTO>> GetVisitanteById(int id)
        {
            var visitante = await _visitanteService.GetVisitanteByIdAsync(id);

            if (visitante is null)
                return NotFound(new { message = "Visitante no encontrado" });

            var dto = new VisitanteDTO
            {
                VisitanteId = visitante.VisitanteId,
                Nombre = visitante.Nombre,
                TipoDocumento = visitante.TipoDocumento,
                Documento = visitante.Documento,
                Telefono = visitante.Telefono,
                FechaRegistro = visitante.FechaRegistro
            };

            return Ok(dto);
        }
        // POST: api/Visitante
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(VisitanteDTO dto)
        {
            var visitante = new Visitante
            {
                VisitanteId = dto.VisitanteId,
                Nombre = dto.Nombre,
                TipoDocumento = dto.TipoDocumento,
                Documento = dto.Documento,
                Telefono = dto.Telefono,
                FechaRegistro = dto.FechaRegistro
            };

            await _visitanteService.CreateVisitanteAsync(visitante);

            return Ok(visitante);
        }

        // PUT: api/Visitante/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVisitante(int id, VisitanteDTO dto)
        {
            var updatedVisitante = await _visitanteService.UpdateVisitanteAsync(id, dto);

            if (updatedVisitante == null)
                return NotFound();

            return Ok(new
            {
                message = "Visitante actualizado correctamente"
            });
        }

        // DELETE: api/Visitante/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVisitante(int id)
        {
            try
            {
                var success = await _visitanteService.DeleteVisitanteAsync(id);
                if (!success)
                    return NotFound(new { message = "Visitante no encontrado" });

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