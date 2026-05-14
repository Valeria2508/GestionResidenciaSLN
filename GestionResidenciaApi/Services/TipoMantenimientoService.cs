using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class TipoMantenimientoService : ITipoMantenimiento
    {
        private readonly ApplicationDbContext _context;

        public TipoMantenimientoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.TipoMantenimiento>> GetTipoMantenimientoAsync()
        {
            return await _context.TipoMantenimiento.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.TipoMantenimiento> GetTipoMantenimientoByIdAsync(int id)
        {
            return await _context.TipoMantenimiento.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.TipoMantenimiento> CreateTipoMantenimientoAsync(GestionResidenciaApi.Models.TipoMantenimiento tipoMantenimiento)
        {
            _context.TipoMantenimiento.Add(tipoMantenimiento);
            await _context.SaveChangesAsync();
            return tipoMantenimiento;
        }

        public async Task<GestionResidenciaApi.Models.TipoMantenimiento?> UpdateTipoMantenimientoAsync(int id, TipoMantenimientoCreateDTO dto)
        {
            var existing = await _context.TipoMantenimiento.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (TipoMantenimientoId) on update
            existing.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteTipoMantenimientoAsync(int id)
        {
            var existente = await _context.TipoMantenimiento.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.TipoMantenimiento.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de tipo de mantenimiento porque tiene registros relacionados.");
            }
        }
    }
}
