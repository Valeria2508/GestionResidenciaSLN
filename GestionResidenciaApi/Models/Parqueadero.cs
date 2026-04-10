using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Parqueadero
    {
        [Key]
        public int ParqueaderoId { get; set; }
        public int UnidadId { get; set; }
        public int TipoParqueaderoId { get; set; }
        public int EstadoParqueaderoId { get; set; }
        public string Numero { get; set; }
    }
}
