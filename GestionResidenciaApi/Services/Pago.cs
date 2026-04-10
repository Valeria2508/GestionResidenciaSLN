using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Pago : IPago
    {
        private readonly ApplicationDbContext _context;

        public Pago(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Pago>> GetPagoAsync()
        {
            return await _context.Pago.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Pago?> GetPagoByIdAsync(int id)
        {
            return await _context.Pago.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Pago> CreatePagoAsync(GestionResidenciaApi.Models.Pago pago)
        {
            await _context.Pago.AddAsync(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<GestionResidenciaApi.Models.Pago?> UpdatePagoAsync(int id, GestionResidenciaApi.Models.Pago pago)
        {
            var existente = await _context.Pago.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(pago);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletePagoAsync(int id)
        {
            var existente = await _context.Pago.FindAsync(id);
            if (existente == null)
                return false;

            _context.Pago.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
