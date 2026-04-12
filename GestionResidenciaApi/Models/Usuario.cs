using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public int RolId { get; set; }
        public int PersonaId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Rol Rol { get; set; } = null!;
        public Persona Persona { get; set; } = null!;
        public ICollection<AuditoriaLogin> Auditorias { get; set; } = new List<AuditoriaLogin>();
        public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
        public ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
        public ICollection<Mensajeria> Mensajerias { get; set; } = new List<Mensajeria>();
        public ICollection<ResidenteUnidad> ResidenteUnidades { get; set; } = new List<ResidenteUnidad>();
        public ICollection<BitacoraVigilancia> Vigilancias { get; set; } = new List<BitacoraVigilancia>();
    }
}
