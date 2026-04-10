namespace GestionResidenciaFront.Data.Models
{
    [Table("ZonaComun")]
    public class ZonaComun
    {
        [Key]
        public int ZonaComunId { get; set; }

        public int? ConjuntoId { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public bool RequierePago { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal? ValorHora { get; set; }

        [ForeignKey("ConjuntoId")]
        public Conjunto? Conjunto { get; set; }
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
    }
}