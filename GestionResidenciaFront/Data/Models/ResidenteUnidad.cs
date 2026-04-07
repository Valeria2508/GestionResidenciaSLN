namespace GestionResidenciaFront.Data.Models
{
    [Table("ResidenteUnidad")]
    public class ResidenteUnidad
    {
        [Key]
        public int ResidenteUnidadId { get; set; }

        public int UsuarioId { get; set; }
        public int UnidadId { get; set; }
        public bool EsPropietario { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; } = null!;

        [ForeignKey("UnidadId")]
        public Apartamentos Apartamento { get; set; } = null!;
    }
}