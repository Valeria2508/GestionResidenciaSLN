namespace GestionResidenciaApi.DTOs
{
    public class AuditoriaLoginCreateDTO
    {
        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public DateTime FechaIntento { get; set; }
        public string Ip { get; set; }
        public bool Exitoso { get; set; }
        public string Motivo { get; set; }
    }
}
