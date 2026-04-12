using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Apartamentos:IApartamentos
    {
        private readonly ApplicationDbContext _context;

        public Apartamentos(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Apartamentos>> GetApartamentosAsync()
        {
            return await _context.Apartamentos.Include(a => a.Torre).ToListAsync();
        }

        public async Task<Apartamentos?> GetApartamentoByIdAsync(int id)
        {
            return await _context.Apartamentos.Include(a => a.Torre).FirstOrDefaultAsync(a => a.UnidadId == id);
        }

        public async Task<Apartamentos> CreateApartamentoAsync(Apartamentos apartamento)
        {
            await _context.Apartamentos.AddAsync(apartamento);
            await _context.SaveChangesAsync();
            return apartamento;
        }

        public async Task<Apartamentos?> UpdateApartamentoAsync(int id, Apartamentos apartamento)
        {
            var existente = await _context.Apartamentos.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(apartamento);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteApartamentoAsync(int id)
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
