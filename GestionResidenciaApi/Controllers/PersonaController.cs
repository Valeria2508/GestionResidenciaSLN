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
    public class PersonaController : ControllerBase
    {
        private readonly IPersona _personaService;

        public PersonaController(IPersona personaService)
        {
            _personaService = personaService;
        }

        // GET: api/Persona
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Persona>>> GetPersona()
        {
            var persona = await _personaService.GetPersonaAsync();
            return Ok(persona);
        }

        // GET: api/Persona/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PersonaDTO>> GetPersonaById(int id)
        {
            var persona = await _personaService.GetPersonaByIdAsync(id);

            if (persona is null)
                return NotFound(new { message = "Persona no encontrado" });

            var dto = new PersonaDTO
            {
                Nombre = persona.Nombre,
                TipoDocumento = persona.TipoDocumento,
                NumeroDocumento = persona.NumeroDocumento,
                Telefono = persona.Telefono,
                Correo = persona.Correo
            };

            return Ok(dto);
        }

        // POST: api/Persona
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Create(PersonaDTO dto)
        {
            var persona = new Persona
            {
                Nombre = dto.Nombre,
                TipoDocumento = dto.TipoDocumento,
                NumeroDocumento = dto.NumeroDocumento,
                Telefono = dto.Telefono,
                Correo = dto.Correo
            };

            await _personaService.CreatePersonaAsync(persona);

            return Ok(persona);
        }

        // PUT: api/Persona/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePersona(int id, PersonaDTO dto)
        {
            var updatedPersona = await _personaService.UpdatePersonaAsync(id, dto);

            if (updatedPersona == null)
                return NotFound();

            return Ok(new
            {
                message = "Persona actualizado correctamente"
            });
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePersona(int id)
        {
            try
            {
                var success = await _personaService.DeletePersonaAsync(id);
                if (!success)
                    return NotFound(new { message = "Persona no encontrado" });

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