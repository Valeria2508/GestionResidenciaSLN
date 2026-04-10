using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        public string Nombre { get; set; }
    }
}
