namespace GestionResidencia.Data.Models
{
    [Table("Mensajeria")]
    public class Mensajeria
    {
        [Key]
        public int MensajeriaId { get; set; }

        public int UnidadId { get; set; }
        public int UsuarioId { get; set; }

        [MaxLength(100)]
        public string? Empresa { get; set; }

        [MaxLength(100)]
        public string? Guia { get; set; }

        public DateTime FechaRecepcion { get; set; } = DateTime.Now;
        public DateTime? FechaEntrega { get; set; }

        [ForeignKey("UnidadId")]
        public Apartamentos Apartamento { get; set; } = null!;

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } = null!;
    }
}