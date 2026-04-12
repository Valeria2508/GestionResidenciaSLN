using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaId { get; set; }
        public int ZonaComunId { get; set; }
        public int UsuarioId { get; set; }
        public int EstadoId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public string Observacion { get; set; }

        public ZonaComun ZonaComun { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
        public Estado Estado { get; set; } = null!;
    }
}
