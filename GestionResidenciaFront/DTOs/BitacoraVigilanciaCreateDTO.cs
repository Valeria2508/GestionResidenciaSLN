namespace GestionResidenciaApi.DTOs
{
    public class BitacoraVigilanciaDTO
    {
        public int VigilanteId { get; set; }
        public int TipoEventoId { get; set; }
        public int IngresoId { get; set; }
        public int UnidadId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Observacion { get; set; }
    }
}
