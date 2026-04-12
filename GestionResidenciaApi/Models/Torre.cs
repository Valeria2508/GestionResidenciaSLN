using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Torre
    {
        [Key]
        public int TorreId { get; set; }
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }

        public Conjunto Conjunto { get; set; } = null!;
        public ICollection<Apartamentos> Apartamentos { get; set; } = new List<Apartamentos>();
    }
}
