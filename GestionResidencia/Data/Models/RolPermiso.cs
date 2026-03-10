namespace GestionResidencia.Data.Models
{
    [Table("RolPermiso")]
    public class RolPermiso
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        [ForeignKey("RolId")]
        public Rol Rol { get; set; } = null!;

        [ForeignKey("PermisoId")]
        public Permiso Permiso { get; set; } = null!;
    }
}