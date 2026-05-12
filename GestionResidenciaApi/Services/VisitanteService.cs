using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class VisitanteService : IVisitante
    {
        private readonly ApplicationDbContext _context;

        public VisitanteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Visitante>> GetVisitanteAsync()
        {
            return await _context.Visitante.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Visitante> GetVisitanteByIdAsync(int id)
        {
            return await _context.Visitante.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Visitante> CreateVisitanteAsync(GestionResidenciaApi.Models.Visitante visitante)
        {
            _context.Visitante.Add(visitante);
            await _context.SaveChangesAsync();
            return visitante;
        }

        public async Task<GestionResidenciaApi.Models.Visitante> UpdateVisitanteAsync(int id, GestionResidenciaApi.Models.Visitante visitante)
        {
            var existente = await _context.Visitante.FindAsync(id);
            if (existente == null)
                return null;

            existente.Telefono = visitante.Telefono;
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
