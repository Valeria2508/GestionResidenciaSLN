namespace GestionResidenciaFront.Data.Models
{
    [Table("CuotaAdministracion")]
    public class CuotaAdministracion
    {
        [Key]
        public int CuotaId { get; set; }

        public int UnidadId { get; set; }
        public int EstadoCuotaId { get; set; }

        public DateOnly Periodo { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal Valor { get; set; }

        public DateOnly FechaLimite { get; set; }
        public DateOnly? FechaPago { get; set; }

        [MaxLength(300)]
        public string? Observacion { get; set; }

        [ForeignKey("UnidadId")]
        public Apartamentos Apartamento { get; set; } = null!;

        [ForeignKey("EstadoCuotaId")]
        public EstadoCuota EstadoCuota { get; set; } = null!;
    }
}