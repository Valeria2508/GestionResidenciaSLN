namespace GestionResidenciaFront.Data.Models
{
    [Table("EstadoReserva")]
    public class EstadoReserva
    {
        [Key]
        public int EstadoReservaId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}