using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class RolService : IRol
    {
        private readonly ApplicationDbContext _context;

        public RolService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Rol>> GetRolAsync()
        {
            return await _context.Rol.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Rol> GetRolByIdAsync(int id)
        {
            return await _context.Rol.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Rol> CreateRolAsync(GestionResidenciaApi.Models.Rol rol)
        {
            _context.Rol.Add(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<Rol?> UpdateRolAsync(int id, RolDTO dto)
        {
            var existing = await _context.Rol.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (RolId) on update
            existing.Nombre = dto.Nombre;

            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteRolAsync(int id)
        {
            var existente = await _context.Rol.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Rol.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de roles porque tiene registros relacionados.");
            }
        }
    }
}
