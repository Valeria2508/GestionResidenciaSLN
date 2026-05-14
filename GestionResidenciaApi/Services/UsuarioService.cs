using GestionResidenciaApi.Data;
using GestionResidenciaApi.DTOs;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionResidenciaApi.Services
{
    public class UsuarioService : IUsuario
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario?> ValidarUsuarioAsync(string username, string password)
        {
            
            // Buscamos el usuario que coincida con el nombre y la clave
            return await _context.Usuario
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
        }
        public async Task<List<GestionResidenciaApi.Models.Usuario>> GetUsuarioAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<GestionResidenciaApi.Models.Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task<GestionResidenciaApi.Models.Usuario> CreateUsuarioAsync(GestionResidenciaApi.Models.Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario?> UpdateUsuarioAsync(int id, UsuarioCreateDTO dto)
        {
            var existing = await _context.Usuario.FindAsync(id);

            if (existing == null)
                return null;

            // Do not modify the primary key (UsuarioId) on update
            existing.RolId = dto.RolId;
            existing.PersonaId = dto.PersonaId;
            existing.Username = dto.Username;
            existing.PasswordHash = dto.PasswordHash;
            existing.Activo = dto.Activo;
            existing.FechaCreacion = dto.FechaCreacion;
            await _context.SaveChangesAsync();

            return existing;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var existente = await _context.Usuario.FindAsync(id);

            if (existente == null)
                return false;

            try
            {
                _context.Usuario.Remove(existente);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede eliminar el registro de usuarios porque tiene registros relacionados.");
            }
        }
    }
}
