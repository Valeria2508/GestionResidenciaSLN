using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Conjunto
    {
        [Key]
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string NIT { get; set; }
        public string Telefono { get; set; }
    }
}
