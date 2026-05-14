using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class PermisoService : IPermiso
    {
        private readonly ApplicationDbContext _context;

        public PermisoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Permiso>> GetPermisoAsync()
        {
            return await _context.Permiso.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Permiso> GetPermisoByIdAsync(int id)
        {
            return await _context.Permiso.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Permiso> CreatePermisoAsync(GestionResidenciaApi.Models.Permiso permiso)
        {
            _context.Permiso.Add(permiso);
            await _context.SaveChangesAsync();
            return permiso;
        }

        public async Task<Permiso?> UpdatePermisoAsync(int id, PermisoDTO dto)
        {
            var existing = await _context.Permiso.FindAsync(id);

            if (existing == null)
                return null;

            // 
            existing.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeletePermisoAsync(int id)
        {
            var existente = await _context.Permiso.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Permiso.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de permisos porque tiene registros relacionados.");
            }
        }
    }
}
