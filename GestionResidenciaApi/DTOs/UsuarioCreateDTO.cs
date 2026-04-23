namespace GestionResidenciaApi.DTOs
{
    public class UsuarioCreateDTO
    {
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public int PersonaId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
