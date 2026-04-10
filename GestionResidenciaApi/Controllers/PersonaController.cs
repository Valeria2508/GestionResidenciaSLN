using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GestionResidenciaApi.Services;
using GestionResidenciaApi.Models;
namespace GestionResidenciaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersona _personaService;

        public PersonaController(IPersona personaService)
        {
            _personaService = personaService;
        }

        // GET: api/Personas
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<GestionResidenciaApi.Models.Persona>>> GetPersonas()
        {
            var personas = await _personaService.GetPersonaAsync();
            return Ok(personas);
        }

        // GET: api/Personas por id/
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Persona>> GetPersona(int id)
        {
            var persona = await _personaService.GetPersonaByIdAsync(id);
            if (persona is null) return NotFound();
            return Ok(persona);
        }

        // POST: api/Personas
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Persona>> CreatePersona(GestionResidenciaApi.Models.Persona persona)
        {
            var createdPersona = await _personaService.CreatePersonaAsync(persona);
            return CreatedAtAction(nameof(GetPersona), new { id = createdPersona.PersonaId }, createdPersona);
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Persona>> UpdatePersona(int id, GestionResidenciaApi.Models.Persona persona)
        {
            var updatedPersona = await _personaService.UpdatePersonaAsync(id, persona);
            if (updatedPersona is null) return NotFound();
            return Ok(updatedPersona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<GestionResidenciaApi.Models.Persona>> DeletePersona(int id)
        {
            var success = await _personaService.DeletePersonaAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
