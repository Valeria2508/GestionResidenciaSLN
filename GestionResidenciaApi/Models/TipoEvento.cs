using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class TipoEvento
    {
        [Key]
        public int TipoEventoId { get; set; }
        public string Nombre { get; set; }
    }
}
