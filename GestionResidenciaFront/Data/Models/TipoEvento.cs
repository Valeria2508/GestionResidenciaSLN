namespace GestionResidenciaFront.Data.Models
{
    [Table("TipoEvento")]
    public class TipoEvento
    {
        [Key]
        public int TipoEventoId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<BitacoraVigilancia> Bitacoras { get; set; } = new List<BitacoraVigilancia>();
    }
}