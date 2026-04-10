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

        public async Task<List<GestionResidenciaApi.Models.Apartamentos>> GetApartamentosAsync()
        {
            return await _context.Apartamentos.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Apartamentos?> GetApartamentoByIdAsync(int id)
        {
            return await _context.Apartamentos.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Apartamentos> CreateApartamentoAsync(GestionResidenciaApi.Models.Apartamentos apartamento)
        {
            await _context.Apartamentos.AddAsync(apartamento);
            await _context.SaveChangesAsync();
            return apartamento;
        }

        public async Task<GestionResidenciaApi.Models.Apartamentos?> UpdateApartamentoAsync(int id, GestionResidenciaApi.Models.Apartamentos apartamento)
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
