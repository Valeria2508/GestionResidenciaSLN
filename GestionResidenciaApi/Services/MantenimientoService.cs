using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class MantenimientoService : IMantenimiento
    {
        private readonly ApplicationDbContext _context;

        public MantenimientoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Mantenimiento>> GetMantenimientoAsync()
        {
            return await _context.Mantenimiento.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Mantenimiento> GetMantenimientoByIdAsync(int id)
        {
            return await _context.Mantenimiento.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Mantenimiento> CreateMantenimientoAsync(GestionResidenciaApi.Models.Mantenimiento mantenimiento)
        {
            _context.Mantenimiento.Add(mantenimiento);
            await _context.SaveChangesAsync();
            return mantenimiento;
        }

        public async Task<GestionResidenciaApi.Models.Mantenimiento?> UpdateMantenimientoAsync(int id, MantenimientoDTO dto)
        {
            var existing = await _context.Mantenimiento.FindAsync(id);

            if (existing == null)
                return null;

            
            existing.Proveedor = dto.Proveedor;
            existing.Fecha = dto.Fecha;
            existing.Descripcion = dto.Descripcion;
            existing.Costo = dto.Costo;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteMantenimientoAsync(int id)
        {
            var existente = await _context.Mantenimiento.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Mantenimiento.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de mantenimiento porque tiene registros relacionados.");
            }
        }
    }
}
