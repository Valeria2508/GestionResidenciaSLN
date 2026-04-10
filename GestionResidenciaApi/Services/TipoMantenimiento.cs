using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoMantenimiento : ITipoMantenimiento
    {
        private readonly ApplicationDbContext _context;

        public TipoMantenimiento(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoMantenimiento>> GetTipoMantenimientoAsync()
        {
            return await _context.TipoMantenimiento.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoMantenimiento?> GetTipoMantenimientoByIdAsync(int id)
        {
            return await _context.TipoMantenimiento.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoMantenimiento> CreateTipoMantenimientoAsync(GestionResidenciaApi.Models.TipoMantenimiento tipoMantenimiento)
        {
            await _context.TipoMantenimiento.AddAsync(tipoMantenimiento);
            await _context.SaveChangesAsync();
            return tipoMantenimiento;
        }

        public async Task<GestionResidenciaApi.Models.TipoMantenimiento?> UpdateTipoMantenimientoAsync(int id, GestionResidenciaApi.Models.TipoMantenimiento tipoMantenimiento)
        {
            var existente = await _context.TipoMantenimiento.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(tipoMantenimiento);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteTipoMantenimientoAsync(int id)
        {
            var existente = await _context.TipoMantenimiento.FindAsync(id);
            if (existente == null)
                return false;

            _context.TipoMantenimiento.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
