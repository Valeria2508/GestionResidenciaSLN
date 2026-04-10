using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class ZonaComun
    {
        [Key]
        public int ZonaComunId { get; set; }
        public int ConjuntoId { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public bool RequierePago { get; set; }
        public decimal ValorHora { get; set; }
    }
}
