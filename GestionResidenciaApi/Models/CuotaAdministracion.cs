using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class CuotaAdministracion
    {
        [Key]
        public int CuotaId { get; set; }
        public int UnidadId { get; set; }
        public int EstadoCuotaId { get; set; }
        public DateOnly Periodo { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime SaldoPendiente { get; set; }
        public string Observacion { get; set; }
    }
}
