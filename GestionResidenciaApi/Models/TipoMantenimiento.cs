using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class TipoMantenimiento
    {
        [Key]
        public int TipoMantenimientoId { get; set; }
        public string Nombre { get; set; }  
    }
}
