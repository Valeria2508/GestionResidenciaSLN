namespace GestionResidenciaFront.Data.Models
{
    [Table("Reserva")]
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }

        public int ZonaComunId { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoReservaId { get; set; }

        public DateOnly Fecha { get; set; }
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }

        [ForeignKey("ZonaComunId")]
        public ZonaComun ZonaComun { get; set; } = null!;

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } = null!;

        [ForeignKey("EstadoReservaId")]
        public EstadoReserva EstadoReserva { get; set; } = null!;
    }
}