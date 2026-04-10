using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class EstadoParqueadero
    {
        [Key]
        public int EstadoParqueaderoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
