namespace GestionResidencia.Data.Models
{
    [Table("Parqueadero")]
    public class Parqueadero
    {
        [Key]
        public int ParqueaderoId { get; set; }

        public int? UnidadId { get; set; }
        public int TipoParqueaderoId { get; set; }

        [Required, MaxLength(20)]
        public string Numero { get; set; } = string.Empty;

        [ForeignKey("UnidadId")]
        public Apartamentos? Apartamento { get; set; }

        [ForeignKey("TipoParqueaderoId")]
        public TipoParqueadero TipoParqueadero { get; set; } = null!;
        public ICollection<ParqueaderoVisitante> Visitantes { get; set; } = new List<ParqueaderoVisitante>();
    }
}