namespace GestionResidenciaApi.DTOs
{
    public class ReservaDTO
    {
        public int ZonaComunId { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Observaciones { get; set; }
    }
}
