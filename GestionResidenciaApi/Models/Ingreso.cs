using System.ComponentModel.DataAnnotations;

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
        public DateTime FechaHoraIngreso { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public string Observacion { get; set; }
    }
}
