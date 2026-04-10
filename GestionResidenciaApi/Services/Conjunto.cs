
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Conjunto : IConjunto
    {
        private readonly ApplicationDbContext _context;

        public Conjunto(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Conjunto>> GetConjuntosAsync()
        {
            return await _context.Conjunto.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Conjunto?> GetConjuntoByIdAsync(int id)
        {
            var existente = await _context.Conjunto.FindAsync(id);
            return existente;
        }

        public async Task<GestionResidenciaApi.Models.Conjunto> CreateConjuntoAsync(GestionResidenciaApi.Models.Conjunto conjunto)
        {
            await _context.Conjunto.AddAsync(conjunto);
            await _context.SaveChangesAsync();
            return conjunto;
        }

        public async Task<GestionResidenciaApi.Models.Conjunto?> UpdateConjuntoAsync(int id, GestionResidenciaApi.Models.Conjunto conjunto)
        {
            var existente = await _context.Conjunto.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(conjunto);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteConjuntoAsync(int id)
        {
            var existente = await _context.Conjunto.FindAsync(id);
            if (existente == null)
                return false;

            _context.Conjunto.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
