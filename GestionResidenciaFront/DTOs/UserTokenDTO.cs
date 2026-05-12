namespace GestionResidenciaApi.DTOs
{
    public class UserTokenDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiracion { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty; // Importante para saber si es Admin o Residente
    }
}