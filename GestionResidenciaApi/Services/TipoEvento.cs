using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoEvento : ITipoEvento
    {
        private readonly ApplicationDbContext _context;

        public TipoEvento(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoEvento>> GetTipoEventoAsync()
        {
            return await _context.TipoEvento.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoEvento?> GetTipoEventoByIdAsync(int id)
        {
            return await _context.TipoEvento.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoEvento> CreateTipoEventoAsync(GestionResidenciaApi.Models.TipoEvento tipoEvento)
        {
            await _context.TipoEvento.AddAsync(tipoEvento);
            await _context.SaveChangesAsync();
            return tipoEvento;
        }

        public async Task<GestionResidenciaApi.Models.TipoEvento?> UpdateTipoEventoAsync(int id, GestionResidenciaApi.Models.TipoEvento tipoEvento)
        {
            var existente = await _context.TipoEvento.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(tipoEvento);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteTipoEventoAsync(int id)
        {
            var existente = await _context.TipoEvento.FindAsync(id);
            if (existente == null)
                return false;

            _context.TipoEvento.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
