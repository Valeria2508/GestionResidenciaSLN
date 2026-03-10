namespace GestionResidencia.Data.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int RolId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public ICollection<RolPermiso> RolPermisos { get; set; } = new List<RolPermiso>();
    }
}