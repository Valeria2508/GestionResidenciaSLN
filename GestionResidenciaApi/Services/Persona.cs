using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Persona : IPersona
    {
        private readonly ApplicationDbContext _context;

        public Persona(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetPersonaAsync()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task<Persona?> GetPersonaByIdAsync(int id)
        {
            return await _context.Persona.FindAsync(id);
        }

        public async Task<Persona> CreatePersonaAsync(Persona persona)
        {
            await _context.Persona.AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<Persona?> UpdatePersonaAsync(int id, Persona persona)
        {
            var existente = await _context.Persona.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(persona);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletePersonaAsync(int id)
        {
            var existente = await _context.Persona.FindAsync(id);
            if (existente == null)
                return false;

            _context.Persona.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
