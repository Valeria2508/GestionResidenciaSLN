using System.Linq;
using GestionResidenciaFront.Data.Models;

namespace GestionResidenciaFront.Services
{
    public class AuthService
    {
        private List<Usuario> usuarios = new()
        {
            new Usuario { Id = 1, UsuarioNombre = "admin", Password = "123", Rol = "Administrador", Activo = true },
            new Usuario { Id = 2, UsuarioNombre = "porteria", Password = "1234", Rol = "Porteria", Activo = true },
            new Usuario { Id = 3, UsuarioNombre = "residente", Password = "12345", Rol = "Residente", Activo = true },
            // Nuevo rol de usuario normal solicitado
            new Usuario { Id = 4, UsuarioNombre = "usuario", Password = "123", Rol = "Usuario", Activo = true }
        };

        public Usuario? Login(string usuario, string password)
        {
            return usuarios.FirstOrDefault(u =>
                u.UsuarioNombre == usuario &&
                u.Password == password &&
                u.Activo);
        }

        // Overload that also validates the role when provided
        public Usuario? Login(string usuario, string password, string? rol)
        {
            var user = Login(usuario, password);
            if (user == null)
                return null;

            if (!string.IsNullOrEmpty(rol) && user.Rol != rol)
                return null;

            return user;
        }
    }
}