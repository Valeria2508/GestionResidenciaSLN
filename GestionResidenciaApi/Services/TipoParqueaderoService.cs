using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoParqueaderoService : ITipoParqueadero
    {
        private readonly ApplicationDbContext _context;

        public TipoParqueaderoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoParqueadero>> GetTipoParqueaderoAsync()
        {
            return await _context.TipoParqueadero.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero> GetTipoParqueaderoByIdAsync(int id)
        {
            return await _context.TipoParqueadero.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero> CreateTipoParqueaderoAsync(GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero)
        {
            _context.TipoParqueadero.Add(tipoParqueadero);
            await _context.SaveChangesAsync();
            return tipoParqueadero;
        }

        public async Task<GestionResidenciaApi.Models.TipoParqueadero> UpdateTipoParqueaderoAsync(int id, GestionResidenciaApi.Models.TipoParqueadero tipoParqueadero)
        {
            var existente = await _context.TipoParqueadero.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nombre = tipoParqueadero.Nombre;
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
