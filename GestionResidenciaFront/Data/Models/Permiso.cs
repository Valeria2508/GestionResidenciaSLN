namespace GestionResidenciaFront.Data.Models
{
    [Table("Permiso")]
    public class Permiso
    {
        [Key]
        public int PermisoId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
    }
}