namespace GestionResidenciaFront.Data.Models
{
    [Table("TipoParqueadero")]
    public class TipoParqueadero
    {
        [Key]
        public int TipoParqueaderoId { get; set; }

        [Required, MaxLength(30)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Parqueadero> Parqueaderos { get; set; } = new List<Parqueadero>();
    }
}