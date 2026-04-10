using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Rol : IRol
    {
        private readonly ApplicationDbContext _context;

        public Rol(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Rol>> GetRolAsync()
        {
            return await _context.Rol.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Rol?> GetRolByIdAsync(int id)
        {
            return await _context.Rol.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Rol> CreateRolAsync(GestionResidenciaApi.Models.Rol rol)
        {
            await _context.Rol.AddAsync(rol);
            await _context.SaveChangesAsync();
            return rol;
        }

        public async Task<GestionResidenciaApi.Models.Rol?> UpdateRolAsync(int id, GestionResidenciaApi.Models.Rol rol)
        {
            var existente = await _context.Rol.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(rol);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteRolAsync(int id)
        {
            var existente = await _context.Rol.FindAsync(id);
            if (existente == null)
                return false;

            _context.Rol.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
