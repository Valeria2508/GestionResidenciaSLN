using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Permiso
    {
        [Key]
        public int PermisoId { get; set; }
        public string Nombre { get; set; }
    }
}
