using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class ZonaComun : IZonaComun
    {
        private readonly ApplicationDbContext _context;

        public ZonaComun(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.ZonaComun>> GetZonaComunAsync()
        {
            return await _context.ZonaComun.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.ZonaComun?> GetZonaComunByIdAsync(int id)
        {
            return await _context.ZonaComun.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.ZonaComun> CreateZonaComunAsync(GestionResidenciaApi.Models.ZonaComun zonaComun)
        {
            await _context.ZonaComun.AddAsync(zonaComun);
            await _context.SaveChangesAsync();
            return zonaComun;
        }

        public async Task<GestionResidenciaApi.Models.ZonaComun?> UpdateZonaComunAsync(int id, GestionResidenciaApi.Models.ZonaComun zonaComun)
        {
            var existente = await _context.ZonaComun.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(zonaComun);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteZonaComunAsync(int id)
        {
            var existente = await _context.ZonaComun.FindAsync(id);
            if (existente == null)
                return false;

            _context.ZonaComun.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
