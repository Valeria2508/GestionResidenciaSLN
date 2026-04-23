using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionResidenciaApi.Models
{
    public class ParqueaderoVisitante
    {
        [Key]
        public int ParqueaderoVisitanteId { get; set; }
        public int ParqueaderoId { get; set; }
        public int IngresoId { get; set; }
        public string Placa { get; set; }
        public DateTime? FechaHoraIngreso { get; set; }
        public DateTime? FechaHoraSalida { get; set; }

        public Parqueadero Parqueadero { get; set; } = null!;
        public Ingreso Ingreso { get; set; } = null!;
    }
}
