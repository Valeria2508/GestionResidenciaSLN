namespace GestionResidenciaFront.Data.Models
{
    [Table("TipoIngreso")]
    public class TipoIngreso
    {
        [Key]
        public int TipoIngresoId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
    }
}