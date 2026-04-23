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
                PersonaId = persona.PersonaId,
            };

            return Ok(dto);
        }

        // POST: api/Persona
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PersonaDTO dto)
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
        public async Task<ActionResult<Persona>> UpdatePersona(int id, [FromBody] Persona persona)
        {
            if (id != persona.PersonaId)
                return BadRequest(new { message = "El ID no coincide" });

            var updatedPersona = await _personaService.UpdatePersonaAsync(id, persona);

            if (updatedPersona is null)
                return NotFound(new { message = "Persona no encontrado" });

            return Ok(updatedPersona);
        }

        // DELETE: api/Persona/5
        [HttpDelete("{id:int}")]
        [Authorize] // puedes dejarlo o quitarlo para pruebas
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var success = await _personaService.DeletePersonaAsync(id);

            if (!success)
                return NotFound(new { message = "Persona no encontrado" });

            return NoContent();
        }
    }
}