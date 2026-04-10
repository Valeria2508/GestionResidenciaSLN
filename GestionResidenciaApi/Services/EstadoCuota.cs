using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class EstadoCuota
    {
        private readonly ApplicationDbContext _context;
        public EstadoCuota(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<GestionResidenciaApi.Models.EstadoCuota>> GetEstadoCuotaAsync()    
        {
            return await _context.EstadoCuota.ToListAsync();
        }
        public async Task<GestionResidenciaApi.Models.EstadoCuota?> GetEstadoCuotaByIdAsync(int id)
        {
            return await _context.EstadoCuota.FindAsync(id);
        }
        public async Task<GestionResidenciaApi.Models.EstadoCuota> CreateEstadoCuotaAsync(GestionResidenciaApi.Models.EstadoCuota estadoCuota)
        {
            await _context.EstadoCuota.AddAsync(estadoCuota);
            await _context.SaveChangesAsync();
            return estadoCuota;
        }
        public async Task<GestionResidenciaApi.Models.EstadoCuota?> UpdateEstadoCuotaAsync(int id, GestionResidenciaApi.Models.EstadoCuota estadoCuota)
        {
            var existente = await _context.EstadoCuota.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(estadoCuota);
            await _context.SaveChangesAsync();
            return existente;
        }
        public async Task<bool> DeleteEstadoCuotaAsync(int id)
        {
            var existente = await _context.EstadoCuota.FindAsync(id);
            if (existente == null)
                return false;

            _context.EstadoCuota.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
