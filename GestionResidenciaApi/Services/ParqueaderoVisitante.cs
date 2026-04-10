using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ParqueaderoVisitante : IParqueaderoVisitante
    {
        private readonly ApplicationDbContext _context;

        public ParqueaderoVisitante(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.ParqueaderoVisitante>> GetParqueaderoVisitanteAsync()
        {
            return await _context.ParqueaderoVisitante.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.ParqueaderoVisitante?> GetParqueaderoVisitanteByIdAsync(int id)
        {
            return await _context.ParqueaderoVisitante.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.ParqueaderoVisitante> CreateParqueaderoVisitanteAsync(GestionResidenciaApi.Models.ParqueaderoVisitante parqueaderoVisitante)
        {
            await _context.ParqueaderoVisitante.AddAsync(parqueaderoVisitante);
            await _context.SaveChangesAsync();
            return parqueaderoVisitante;
        }

        public async Task<GestionResidenciaApi.Models.ParqueaderoVisitante?> UpdateParqueaderoVisitanteAsync(int id, GestionResidenciaApi.Models.ParqueaderoVisitante parqueaderoVisitante)
        {
            var existente = await _context.ParqueaderoVisitante.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(parqueaderoVisitante);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteParqueaderoVisitanteAsync(int id)
        {
            var existente = await _context.ParqueaderoVisitante.FindAsync(id);
            if (existente == null)
                return false;

            _context.ParqueaderoVisitante.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
