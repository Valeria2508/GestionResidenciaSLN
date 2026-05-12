using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionResidenciaApi.Models
{
    public class Parqueadero
    {
        [Key]
        public int ParqueaderoId { get; set; }
        public int UnidadId { get; set; }
        public int TipoParqueaderoId { get; set; }
        public int EstadoId { get; set; }
        public string Numero { get; set; }

        public Apartamentos Unidad { get; set; } = null!;
        public TipoParqueadero TipoParqueadero { get; set; } = null!;
        public Estado Estado { get; set; } = null!;
        public ICollection<ParqueaderoVisitante> ParqueaderoVisitantes { get; set; } = new List<ParqueaderoVisitante>();
    }
}
