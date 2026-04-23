namespace GestionResidenciaApi.DTOs
{
    public class IngresoDTO
    {
        public int TipoIngresoId { get; set; }
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int VisitanteId { get; set; }
        public string NombrePersona { get; set; }
        public string Documento { get; set; }
        public string Vehiculo { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Observacion { get; set; }
    }
}
