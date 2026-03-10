namespace GestionResidencia.Data.Models
{
    [Table("TipoMantenimiento")]
    public class TipoMantenimiento
    {
        [Key]
        public int TipoMantenimientoId { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
    }
}