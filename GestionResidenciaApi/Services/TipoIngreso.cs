using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoIngreso : ITipoIngreso
    {
        private readonly ApplicationDbContext _context;

        public TipoIngreso(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoIngreso>> GetTipoIngresoAsync()
        {
            return await _context.TipoIngreso.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoIngreso?> GetTipoIngresoByIdAsync(int id)
        {
            return await _context.TipoIngreso.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoIngreso> CreateTipoIngresoAsync(GestionResidenciaApi.Models.TipoIngreso tipoIngreso)
        {
            await _context.TipoIngreso.AddAsync(tipoIngreso);
            await _context.SaveChangesAsync();
            return tipoIngreso;
        }

        public async Task<GestionResidenciaApi.Models.TipoIngreso?> UpdateTipoIngresoAsync(int id, GestionResidenciaApi.Models.TipoIngreso tipoIngreso)
        {
            var existente = await _context.TipoIngreso.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(tipoIngreso);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteTipoIngresoAsync(int id)
        {
            var existente = await _context.TipoIngreso.FindAsync(id);
            if (existente == null)
                return false;

            _context.TipoIngreso.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
