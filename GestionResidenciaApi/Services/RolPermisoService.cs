using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class RolPermisoService : IRolPermiso
    {
        private readonly ApplicationDbContext _context;

        public RolPermisoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.RolPermiso>> GetRolPermisoAsync()
        {
            return await _context.RolPermiso.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.RolPermiso> GetRolPermisoByIdAsync(int rolId, int permisoId)
        {
            return await _context.RolPermiso.FindAsync(rolId, permisoId);
        }

        public async Task<GestionResidenciaApi.Models.RolPermiso> CreateRolPermisoAsync(GestionResidenciaApi.Models.RolPermiso rolPermiso)
        {
            _context.RolPermiso.Add(rolPermiso);
            await _context.SaveChangesAsync();
            return rolPermiso;
        }

        public async Task<RolPermiso?> UpdateRolPermisoAsync(int rolId, int permisoId, RolPermisoDTO dto)
        {
            var existing = await _context.RolPermiso.FindAsync(rolId, permisoId);

            if (existing == null)
                return null;

            // Do not modify key properties of an entity with a composite key.
            // If you need to change the keys, delete and recreate the relationship instead.
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteRolPermisoAsync(int rolId, int permisoId)
        {
            var existente = await _context.RolPermiso.FindAsync(rolId, permisoId);

            if (existente == null)
                return false;

            try
            {
                _context.RolPermiso.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de RolPermiso porque tiene registros relacionados.");
            }
        }
    }
}
