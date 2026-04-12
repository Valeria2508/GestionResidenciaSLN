using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class TipoParqueadero
    {
        [Key]
        public int TipoParqueaderoId { get; set; }
        public string Nombre { get; set; }

        public ICollection<Parqueadero> Parqueaderos { get; set; } = new List<Parqueadero>();
    }
}
