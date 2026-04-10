using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class MetodoPago : IMetodoPago
    {
        private readonly ApplicationDbContext _context;

        public MetodoPago(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.MetodoPago>> GetMetodoPagoAsync()
        {
            return await _context.MetodoPago.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.MetodoPago?> GetMetodoPagoByIdAsync(int id)
        {
            return await _context.MetodoPago.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.MetodoPago> CreateMetodoPagoAsync(GestionResidenciaApi.Models.MetodoPago metodoPago   )
        {
            await _context.MetodoPago.AddAsync(metodoPago);
            await _context.SaveChangesAsync();
            return metodoPago;
        }

        public async Task<GestionResidenciaApi.Models.MetodoPago?> UpdateMetodoPagoAsync(int id, GestionResidenciaApi.Models.MetodoPago metodoPago)
        {
            var existente = await _context.MetodoPago.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(metodoPago);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteMetodoPagoAsync(int id)
        {
            var existente = await _context.MetodoPago.FindAsync(id);
            if (existente == null)
                return false;

            _context.MetodoPago.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
