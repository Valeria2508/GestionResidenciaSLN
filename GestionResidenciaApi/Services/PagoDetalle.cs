using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class PagoDetalle : IPagoDetalle
    {
        private readonly ApplicationDbContext _context;

        public PagoDetalle(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.PagoDetalle>> GetPagoDetallesAsync()
        {
            return await _context.PagoDetalle.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.PagoDetalle?> GetPagoDetalleByIdAsync(int id)
        {
            return await _context.PagoDetalle.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.PagoDetalle> CreatePagoDetalleAsync(GestionResidenciaApi.Models.PagoDetalle pagodetalle)
        {
            await _context.PagoDetalle.AddAsync(pagodetalle);
            await _context.SaveChangesAsync();
            return pagodetalle;
        }

        public async Task<GestionResidenciaApi.Models.PagoDetalle?> UpdatePagoDetalleAsync(int id, GestionResidenciaApi.Models.PagoDetalle pagodetalle)
        {
            var existente = await _context.PagoDetalle.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(pagodetalle);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletePagoDetalleAsync(int id)
        {
            var existente = await _context.PagoDetalle.FindAsync(id);
            if (existente == null)
                return false;

            _context.PagoDetalle.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
