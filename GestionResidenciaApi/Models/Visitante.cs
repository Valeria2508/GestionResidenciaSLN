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
    }
}
