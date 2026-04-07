namespace GestionResidenciaFront.Data.Models
{
    [Table("AuditoriaLogin")]
    public class AuditoriaLogin
    {
        [Key]
        public int AuditoriaId { get; set; }

        public int? UsuarioId { get; set; }

        [MaxLength(50)]
        public string? Username { get; set; }

        public DateTime FechaIntento { get; set; } = DateTime.Now;

        [MaxLength(45)]
        public string? Ip { get; set; }

        public bool? Exitoso { get; set; }

        [MaxLength(200)]
        public string? Motivo { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }
    }
}