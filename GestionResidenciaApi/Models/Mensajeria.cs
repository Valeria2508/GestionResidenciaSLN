using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Mensajeria
    {
        [Key]
        public int MensajeriaId { get; set; }
        public int UnidadId { get; set; }
        public int UsuarioId { get; set; }
        public string Empresa { get; set; }
        public string Guia { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
