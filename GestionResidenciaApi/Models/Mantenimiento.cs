using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Mantenimiento
    {
        [Key]
        public int MantenimientoId { get; set; }
        public int TipoMantenimientoId { get; set; }
        public int ZonaComunId { get; set; }
        public int UnidadId { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }

        public TipoMantenimiento TipoMantenimiento { get; set; } = null!;
        public ZonaComun ZonaComun { get; set; } = null!;
        public Apartamentos Unidad { get; set; } = null!;
    }
}
