namespace GestionResidencia.Data.Models
{
    [Table("Apartamentos")]
    public class Apartamentos
    {
        [Key]
        public int UnidadId { get; set; }

        public int? TorreId { get; set; }

        [Required, MaxLength(20)]
        public string Numero { get; set; } = string.Empty;

        [Required, MaxLength(30)]
        public string Tipo { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Area { get; set; }

        [ForeignKey("TorreId")]
        public Torre? Torre { get; set; }
        public ICollection<ResidenteUnidad> Residentes { get; set; } = new List<ResidenteUnidad>();
        public ICollection<Parqueadero> Parqueaderos { get; set; } = new List<Parqueadero>();
        public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
        public ICollection<CuotaAdministracion> Cuotas { get; set; } = new List<CuotaAdministracion>();
    }
}
