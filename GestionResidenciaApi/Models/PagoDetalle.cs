using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class PagoDetalle
    {
        [Key]
        public int PagoDetalleId { get; set; }
        public int PagoId { get; set; }
        public int CuotaId { get; set; }
        public decimal ValorAbonado { get; set; }

        public Pago Pago { get; set; } = null!;
        public CuotaAdministracion Cuota { get; set; } = null!;
    }
}
