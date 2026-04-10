using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Visitante : IVisitante
    {
        private readonly ApplicationDbContext _context;

        public Visitante(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Visitante>> GetVisitanteAsync()
        {
            return await _context.Visitante.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Visitante?> GetVisitanteByIdAsync(int id)
        {
            return await _context.Visitante.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Visitante> CreateVisitanteAsync(GestionResidenciaApi.Models.Visitante visitante)
        {
            await _context.Visitante.AddAsync(visitante);
            await _context.SaveChangesAsync();
            return visitante;
        }

        public async Task<GestionResidenciaApi.Models.Visitante?> UpdateVisitanteAsync(int id, GestionResidenciaApi.Models.Visitante visitante)
        {
            var existente = await _context.Visitante.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(visitante);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteVisitanteAsync(int id)
        {
            var existente = await _context.Visitante.FindAsync(id);
            if (existente == null)
                return false;

            _context.Visitante.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
