using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class PersonaService : IPersona
    {
        private readonly ApplicationDbContext _context;

        public PersonaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Persona>> GetPersonaAsync()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Persona> GetPersonaByIdAsync(int id)
        {
            return await _context.Persona.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Persona> CreatePersonaAsync(GestionResidenciaApi.Models.Persona persona)
        {
            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<GestionResidenciaApi.Models.Persona> UpdatePersonaAsync(int id, PersonaDTO dto)
        {
            var persona = await _context.Persona.FindAsync(id);

            if (persona == null)
                return null;

            persona.TipoDocumento = dto.TipoDocumento;
            persona.NumeroDocumento = dto.NumeroDocumento;
            persona.Nombre = dto.Nombre;
            persona.Telefono = dto.Telefono;
            persona.Correo = dto.Correo;

            await _context.SaveChangesAsync();

            return persona;
        }

        public async Task<bool> DeletePersonaAsync(int id)
        {
            var existente = await _context.Persona.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Persona.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de personas porque tiene registros relacionados.");
            }
        }
    }
}
