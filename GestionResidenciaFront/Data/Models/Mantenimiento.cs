namespace GestionResidenciaFront.Data.Models
{
    [Table("Mantenimiento")]
    public class Mantenimiento
    {
        [Key]
        public int MantenimientoId { get; set; }

        public int TipoMantenimientoId { get; set; }
        public int? ZonaComunId { get; set; }
        public int? UnidadId { get; set; }

        public DateOnly Fecha { get; set; }

        [MaxLength(150)]
        public string? Proveedor { get; set; }

        [MaxLength(300)]
        public string? Descripcion { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal? Costo { get; set; }

        [ForeignKey("TipoMantenimientoId")]
        public TipoMantenimiento TipoMantenimiento { get; set; } = null!;

        [ForeignKey("ZonaComunId")]
        public ZonaComun? ZonaComun { get; set; }

        [ForeignKey("UnidadId")]
        public Apartamentos? Apartamento { get; set; }
    }
}