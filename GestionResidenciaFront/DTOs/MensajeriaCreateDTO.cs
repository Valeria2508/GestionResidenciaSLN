namespace GestionResidenciaApi.DTOs
{
    public class MensajeriaDTO
    {
        public int UnidadId { get; set; }
        public int UsuarioId { get; set; }
        public string Empresa { get; set; }
        public string Guia { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
