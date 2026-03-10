using GestionResidencia.Data.Models;

namespace GestionResidencia.Services
{
    public class SessionService
    {
        public Usuario? UsuarioActual { get; set; }

        public bool EstaLogueado => UsuarioActual != null;

        public void Logout()
        {
            UsuarioActual = null;
        }
    }
}