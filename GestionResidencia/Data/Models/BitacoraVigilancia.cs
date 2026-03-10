namespace GestionResidencia.Data.Models
{
    [Table("BitacoraVigilancia")]
    public class BitacoraVigilancia
    {
        [Key]
        public int BitacoraId { get; set; }

        public int VigilanteId { get; set; }
        public int? TipoEventoId { get; set; }
        public int? IngresoId { get; set; }
        public int? UnidadId { get; set; }

        public DateTime FechaHora { get; set; } = DateTime.Now;

        [MaxLength(500)]
        public string? Observacion { get; set; }

        [ForeignKey("VigilanteId")]
        public Usuario Vigilante { get; set; } = null!;

        [ForeignKey("TipoEventoId")]
        public TipoEvento? TipoEvento { get; set; }

        [ForeignKey("IngresoId")]
        public Ingreso? Ingreso { get; set; }

        [ForeignKey("UnidadId")]
        public Apartamentos? Apartamento { get; set; }
    }
}