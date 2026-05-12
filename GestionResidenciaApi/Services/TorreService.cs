using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TorreService : ITorre
    {
        private readonly ApplicationDbContext _context;

        public TorreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Torre>> GetTorreAsync()
        {
            return await _context.Torre.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Torre> GetTorreByIdAsync(int id)
        {
            return await _context.Torre.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Torre> CreateTorreAsync(GestionResidenciaApi.Models.Torre torre)
        {
            _context.Torre.Add(torre);
            await _context.SaveChangesAsync();
            return torre;
        }

        public async Task<GestionResidenciaApi.Models.Torre> UpdateTorreAsync(int id, GestionResidenciaApi.Models.Torre torre)
        {
            var existente = await _context.Torre.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nombre = torre.Nombre;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteTorreAsync(int id)
        {
            var existente = await _context.Torre.FindAsync(id);
            if (existente == null)
                return false;

            _context.Torre.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
