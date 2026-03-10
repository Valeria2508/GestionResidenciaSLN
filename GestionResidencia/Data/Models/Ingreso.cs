namespace GestionResidencia.Data.Models
{
    [Table("Ingreso")]
    public class Ingreso
    {
        [Key]
        public int IngresoId { get; set; }

        public int TipoIngresoId { get; set; }
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }

        [Required, MaxLength(150)]
        public string NombrePersona { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? Documento { get; set; }

        public DateTime FechaHoraIngreso { get; set; } = DateTime.Now;
        public DateTime? FechaHoraSalida { get; set; }

        [ForeignKey("TipoIngresoId")]
        public TipoIngreso TipoIngreso { get; set; } = null!;

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } = null!;

        [ForeignKey("UnidadId")]
        public Apartamentos Apartamento { get; set; } = null!;
        public ICollection<ParqueaderoVisitante> ParqueaderosVisitante { get; set; } = new List<ParqueaderoVisitante>();
    }
}