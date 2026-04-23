using GestionResidenciaApi.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionResidenciaApi.Models
{
    public class CuotaAdministracion
    {
        [Key]
        public int CuotaId { get; set; }
        public int UnidadId { get; set; }
        public int EstadoId { get; set; }
        // Periodo: usar DateTime o YearMonth; DateOnly está disponible en .NET 6+, keep as DateOnly for simplicity
        public DateOnly Periodo { get; set; }
        public decimal Valor { get; set; }
        public DateTime FechaLimite { get; set; }
        // saldo pendiente debe ser un monto (decimal), no una fecha
        public decimal SaldoPendiente { get; set; }
        public string Observacion { get; set; }  

        public Estado Estado { get; set; } = null!;
        public Apartamentos Unidad { get; set; } = null!;
        public ICollection<PagoDetalle> PagoDetalles { get; set; } = new List<PagoDetalle>();
    }
}