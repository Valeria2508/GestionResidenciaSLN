using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
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

        public async Task<GestionResidenciaApi.Models.RolPermiso> GetRolPermisoByIdAsync(int id)
        {
            return await _context.RolPermiso.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.RolPermiso> CreateRolPermisoAsync(GestionResidenciaApi.Models.RolPermiso rolPermiso)
        {
            _context.RolPermiso.Add(rolPermiso);
            await _context.SaveChangesAsync();
            return rolPermiso;
        }

        public async Task<GestionResidenciaApi.Models.RolPermiso?> UpdateRolPermisoAsync(int id, GestionResidenciaApi.Models.RolPermiso rolPermiso)
        {
            var existente = await _context.RolPermiso.FindAsync(id);
            if (existente == null)
                return null;

            existente.RolId = rolPermiso.RolId;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteRolPermisoAsync(int id)
        {
            var existente = await _context.RolPermiso.FindAsync(id);
            if (existente == null)
                return false;

            _context.RolPermiso.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
