using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Apartamentos
    {
        [Key]
        public int UnidadId { get; set; }
        public int TorreId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public decimal Area { get; set; }
    }
}
