using GestionResidenciaApi.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionResidenciaApi.Models
{
    public class Pago
    {
        [Key]
        public int PagoId { get; set; }
        public int UsuarioId { get; set; }
        public int MetodoPagoId { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal ValorTotal { get; set; }
        public string Referencia { get; set; }
        public string PagoObservacionId { get; set; }

        public Usuario Usuario { get; set; } = null!;
        public MetodoPago MetodoPago { get; set; } = null!;
        public ICollection<PagoDetalle> PagoDetalles { get; set; } = new List<PagoDetalle>();
    }
}
