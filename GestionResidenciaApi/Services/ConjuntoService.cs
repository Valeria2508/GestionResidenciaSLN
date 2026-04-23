
using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ConjuntoService : IConjunto
    {
        private readonly ApplicationDbContext _context;

        public ConjuntoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Conjunto>> GetConjuntosAsync()
        {
            return await _context.Conjunto.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Conjunto> GetConjuntoByIdAsync(int id)
        {
            var existente = await _context.Conjunto.FindAsync(id);
            return existente;
        }

        public async Task<GestionResidenciaApi.Models.Conjunto> CreateConjuntoAsync(GestionResidenciaApi.Models.Conjunto conjunto)
        {
            _context.Conjunto.Add(conjunto);
            await _context.SaveChangesAsync();
            return conjunto;
        }

        public async Task<GestionResidenciaApi.Models.Conjunto> UpdateConjuntoAsync(int id, GestionResidenciaApi.Models.Conjunto conjunto)
        {
            var existente = await _context.Conjunto.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nombre = conjunto.Nombre;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteConjuntoAsync(int id)
        {
            var existente = await _context.Apartamentos.FindAsync(id);
            if (existente == null)
                return false;

            _context.Apartamentos.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
