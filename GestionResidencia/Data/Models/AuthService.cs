namespace GestionResidencia.Data.Models
{
    public class AuthService
    {
        private List<Usuario> usuarios = new List<Usuario>()
        {
            new Usuario { Id = 1, UsuarioNombre = "admin", Password = "123", Rol = "Administrador", Activo = true },
            new Usuario { Id = 2, UsuarioNombre = "porteria", Password = "123", Rol = "Porteria", Activo = true },
            new Usuario { Id = 3, UsuarioNombre = "residente", Password = "123", Rol = "Residente", Activo = true }
        };

        public Usuario? Login(string usuario, string password, string rol)
        {
            return usuarios.FirstOrDefault(u =>
                u.UsuarioNombre == usuario &&
                u.Password == password &&
                u.Rol == rol &&
                u.Activo);
        }
    }
}