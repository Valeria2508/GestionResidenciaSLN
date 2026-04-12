using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class MetodoPago
    {
        [Key]
        public int MetodoPagoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Pago> Pagos { get; set; } = new List<Pago>();
    }
}
