
namespace GestionResidenciaApi.Models
{
    public class RolPermiso
    {
        // composite key configured in ApplicationDbContext.OnModelCreating
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        public Rol Rol { get; set; } = null!;
        public Permiso Permiso { get; set; } = null!;
    }
}
