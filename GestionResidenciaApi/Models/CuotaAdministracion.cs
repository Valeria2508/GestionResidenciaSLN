using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GestionResidenciaApi.Models
{
    public class CuotaAdministracion
    {
        [Key]
        public int CuotaId { get; set; }
        public int UnidadId { get; set; }
        public int EstadoId { get; set; }
        public DateOnly Periodo { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime SaldoPendiente { get; set; }
        public string Observacion { get; set; }

        public Estado Estado { get; set; } = null!;
        public Apartamentos Unidad { get; set; } = null!;
        public ICollection<PagoDetalle> PagoDetalles { get; set; } = new List<PagoDetalle>();
    }
}
