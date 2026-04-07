namespace GestionResidenciaFront.Data.Models
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }

        [MaxLength(20)]
        public string? TipoDocumento { get; set; }

        [Required, MaxLength(20)]
        public string NumeroDocumento { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Telefono { get; set; }

        [MaxLength(100)]
        public string? Correo { get; set; }

        public Usuario? Usuario { get; set; }
    }
}