using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
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

        public async Task<GestionResidenciaApi.Models.Permiso> UpdatePermisoAsync(int id, GestionResidenciaApi.Models.Permiso permiso)
        {
            var existente = await _context.Permiso.FindAsync(id);
            if (existente == null)
                return null;

            existente.Nombre = permiso.Nombre;
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeletePermisoAsync(int id)
        {
            var existente = await _context.Permiso.FindAsync(id);
            if (existente == null)
                return false;

            _context.Permiso.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
