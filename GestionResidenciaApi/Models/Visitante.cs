using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Visitante
    {
        [Key]
        public int VisitanteId { get; set; }
        public string Nombre { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }

        public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
        public ICollection<ParqueaderoVisitante> ParqueaderoVisitantes { get; set; } = new List<ParqueaderoVisitante>();
    }
}
