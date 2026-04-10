using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class EstadoCuota
    {
        [Key]
        public int EstadoCuotaId { get; set; }
        public string Nombre { get; set; }
    }
}
