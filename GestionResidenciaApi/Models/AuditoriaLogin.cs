using GestionResidenciaApi.Services;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class AuditoriaLogin
    {
        [Key]
        public int AuditoriaId { get; set; }

        public int UsuarioId { get; set; }
        public string Username { get; set; }
        public DateTime FechaIntento { get; set; }
        public string Ip { get; set; }
        public bool Exitoso { get; set; }
        public String Motivo { get; set; }

        public Usuario? Usuario { get; set; } = null!;
    }
}
