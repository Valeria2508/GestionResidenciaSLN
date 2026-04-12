using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string TipoEstado { get; set; }

        public ICollection<CuotaAdministracion> Cuotas { get; set; } = new List<CuotaAdministracion>();
        public ICollection<Parqueadero> Parqueaderos { get; set; } = new List<Parqueadero>();
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
