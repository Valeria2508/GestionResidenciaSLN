using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Mantenimiento : IMantenimiento
    {
        private readonly ApplicationDbContext _context;

        public Mantenimiento(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Mantenimiento>> GetMantenimientoAsync()
        {
            return await _context.Mantenimiento.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Mantenimiento?> GetMantenimientoByIdAsync(int id)
        {
            return await _context.Mantenimiento.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Mantenimiento> CreateMantenimientoAsync(GestionResidenciaApi.Models.Mantenimiento mantenimiento)
        {
            await _context.Mantenimiento.AddAsync(mantenimiento);
            await _context.SaveChangesAsync();
            return mantenimiento;
        }

        public async Task<GestionResidenciaApi.Models.Mantenimiento?> UpdateMantenimientoAsync(int id, GestionResidenciaApi.Models.Mantenimiento mantenimiento)
        {
            var existente = await _context.Mantenimiento.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(mantenimiento);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteMantenimientoAsync(int id)
        {
            var existente = await _context.Mantenimiento.FindAsync(id);
            if (existente == null)
                return false;

            _context.Mantenimiento.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
