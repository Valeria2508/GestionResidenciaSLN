namespace GestionResidencia.Data.Models
{
    [Table("EstadoCuota")]
    public class EstadoCuota
    {
        [Key]
        public int EstadoCuotaId { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<CuotaAdministracion> Cuotas { get; set; } = new List<CuotaAdministracion>();
    }
}