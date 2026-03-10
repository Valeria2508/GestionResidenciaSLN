namespace GestionResidencia.Data.Models
{
    public class SessionService
    {
        public string NombreUsuario { get; private set; } = "";
        public string Rol { get; private set; } = "";
        public string Apartamento { get; private set; } = "";
        public bool EstaLogueado => !string.IsNullOrEmpty(Rol);

        public event Action? OnChange;

        public void Iniciar(string nombre, string rol, string apartamento = "")
        {
            NombreUsuario = nombre;
            Rol = rol;
            Apartamento = apartamento;
            OnChange?.Invoke();
        }

        public void Cerrar()
        {
            NombreUsuario = "";
            Rol = "";
            Apartamento = "";
            OnChange?.Invoke();
        }

        public string Inicial => NombreUsuario.Length > 0
            ? NombreUsuario[0].ToString().ToUpper() : "?";

        public string TemaColor => Rol switch
        {
            "Administrador" => "theme-admin",
            "Vigilante" => "theme-vig",
            "Propietario" => "theme-prop",
            "Visitante" => "theme-vis",
            _ => "theme-admin"
        };

        public string IconoRol => Rol switch
        {
            "Administrador" => "👑",
            "Vigilante" => "🛡️",
            "Propietario" => "🏠",
            "Visitante" => "🪪",
            _ => "👤"
        };
    }
}