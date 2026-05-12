namespace GestionResidenciaApi.DTOs
{
    public class VisitanteDTO
    {
        public int VisitanteId { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
