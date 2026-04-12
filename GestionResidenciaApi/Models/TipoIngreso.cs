using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class TipoIngreso
    {
        [Key]
        public int TipoIngresoId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
    }
}
