using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class ResidenteUnidad
    {
        [Key]
        public int ResidenteUnidadId { get; set; }
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int EsPropietario { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observacion { get; set; }
    }
}
