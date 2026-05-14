using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
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

        public async Task<Torre?> UpdateTorreAsync(int id, TorreCreateDTO dto)
        {
            var existing = await _context.Torre.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (TorreId) on update
            existing.Nombre = dto.Nombre;
            existing.ConjuntoId = dto.ConjuntoId;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteTorreAsync(int id)
        {
            var existente = await _context.Torre.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Torre.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de torres porque tiene registros relacionados.");
            }
        }
    }
}
