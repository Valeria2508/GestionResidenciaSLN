using GestionResidenciaApi.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionResidenciaApi.Models
{
    public class Ingreso
    {
        [Key]
        public int IngresoId { get; set; }
        public int TipoIngresoId { get; set; }
        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public int VisitanteId { get; set; }
        public string NombrePersona { get; set; }
        public string Documento { get; set; }
        public string Vehiculo { get; set; }
        public DateTime? FechaHoraIngreso { get; set; }
        public DateTime? FechaHoraSalida { get; set; }
        public string Observacion { get; set; }

        public TipoIngreso TipoIngreso { get; set; } = null!;
        public Usuario Usuario { get; set; } = null!;
        public Apartamentos Unidad { get; set; } = null!;
        public Visitante Visitante { get; set; } = null!;
        public ICollection<BitacoraVigilancia> Bitacoras { get; set; } = new List<BitacoraVigilancia>();
        public ICollection<ParqueaderoVisitante> ParqueaderoVisitantes { get; set; } = new List<ParqueaderoVisitante>();
    }
}
