namespace GestionResidenciaApi.DTOs
{
    public class MantenimientoDTO
    {
        public int MantenimientoId { get; set; }
        public int ZonaComunId { get; set; }
        public int TipoMantenimientoId { get; set; }
        public int UnidadId { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
    }
}
