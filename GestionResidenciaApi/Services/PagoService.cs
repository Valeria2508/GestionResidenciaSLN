using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class PagoService : IPago
    {
        private readonly ApplicationDbContext _context;

        public PagoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Pago>> GetPagoAsync()
        {
            return await _context.Pago.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Pago> GetPagoByIdAsync(int id)
        {
            return await _context.Pago.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Pago> CreatePagoAsync(GestionResidenciaApi.Models.Pago pago)
        {
            _context.Pago.Add(pago);
            await _context.SaveChangesAsync();
            return pago;
        }

        public async Task<GestionResidenciaApi.Models.Pago> UpdatePagoAsync(int id, GestionResidenciaApi.Models.Pago pago)
        {
            var existente = await _context.Pago.FindAsync(id);
            if (existente == null)
                return null;

            existente.FechaPago = pago.FechaPago;
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
