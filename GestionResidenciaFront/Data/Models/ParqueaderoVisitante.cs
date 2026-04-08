namespace GestionResidenciaFront.Data.Models
{
    [Table("ParqueaderoVisitante")]
    public class ParqueaderoVisitante
    {
        [Key]
        public int ParqueaderoVisitanteId { get; set; }

        public int ParqueaderoId { get; set; }
        public int IngresoId { get; set; }

        [Required, MaxLength(20)]
        public string Placa { get; set; } = string.Empty;

        public DateTime FechaHoraIngreso { get; set; } = DateTime.Now;
        public DateTime? FechaHoraSalida { get; set; }

        [ForeignKey("ParqueaderoId")]
        public Parqueadero Parqueadero { get; set; } = null!;

        [ForeignKey("IngresoId")]
        public Ingreso Ingreso { get; set; } = null!;
    }
}