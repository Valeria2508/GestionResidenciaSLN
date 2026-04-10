using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class RolPermiso
    {
        [Key]
        public int RolId { get; set; }
        public int PermisoId { get; set; }
    }
}
