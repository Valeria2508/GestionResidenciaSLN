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

        public async Task<List<Usuario>> GetUsuarioAsync()
        {
            return await _context.Usuario.Include(u => u.Rol).Include(u => u.Persona).ToListAsync();
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuario.Include(u => u.Rol).Include(u => u.Persona).FirstOrDefaultAsync(u => u.UsuarioId == id);
        }

        public async Task<Usuario> CreateUsuarioAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateUsuarioAsync(int id, Usuario usuario)
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
