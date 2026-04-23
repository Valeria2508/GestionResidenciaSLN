using GestionResidenciaApi.Services;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class BitacoraVigilancia
    {
        [Key]
        public int BitacoraId { get; set; }
        public int VigilanteId { get; set; }
        public int TipoEventoId { get; set; }
        public int IngresoId { get; set; }
        public int UnidadId { get; set; }
        public DateTime? FechaHora { get; set; }
        public string Observacion { get; set; } = null!;

        public Usuario Vigilante { get; set; } = null!;
        public TipoEvento TipoEvento { get; set; } = null!;
        public Ingreso Ingreso { get; set; } = null!;
        public Apartamentos Unidad { get; set; } = null!;
    }
}
