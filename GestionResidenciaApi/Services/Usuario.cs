using GestionResidenciaApi.Models;
using GestionResidenciaApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class Usuario : IUsuario
    {
        private readonly ApplicationDbContext _context;

        public Usuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<GestionResidenciaApi.Models.Usuario>> GetUsuarioAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Usuario> CreateUsuarioAsync(GestionResidenciaApi.Models.Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<GestionResidenciaApi.Models.Usuario?> UpdateUsuarioAsync(int id, GestionResidenciaApi.Models.Usuario usuario)
        {
            var existente = await _context.Usuario.FindAsync(id);
            if (existente == null)
                return null;

            _context.Entry(existente).CurrentValues.SetValues(usuario);
            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var existente = await _context.Usuario.FindAsync(id);
            if (existente == null)
                return false;

            _context.Usuario.Remove(existente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
