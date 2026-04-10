using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoParqueadero : ITipoParqueadero
    {
        private readonly ApplicationDbContext _context;

        public TipoParqueadero(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoParqueadero>> GetTipoParqueaderoAsync()
        {
            return await _context.TipoParqueadero.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero?> GetTipoParqueaderoByIdAsync(int id)
        {
            return await _context.TipoParqueadero.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero> CreateTipoParqueaderoAsync(GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero)
        {
            await _context.TipoParqueadero.AddAsync(tipoParqueadero);
            await _context.SaveChangesAsync();
            return tipoParqueadero;
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero?> UpdateTipoParqueaderoAsync(int id, GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero)
        {
            var existente = await _context.TipoParqueadero.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(tipoParqueadero);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteTipoParqueaderoAsync(int id)
        {
            var existente = await _context.TipoParqueadero.FindAsync(id);
            if (existente == null)
                return false;

            _context.TipoParqueadero.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
