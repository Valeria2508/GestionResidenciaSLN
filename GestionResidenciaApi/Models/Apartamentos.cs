using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionResidenciaApi.Models
{
    public class Apartamentos
    {
        [Key]
        public int UnidadId { get; set; }
        public int TorreId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public int Area { get; set; }

        public Torre Torre { get; set; } = null!;
        public ICollection<CuotaAdministracion> Cuotas { get; set; } = new List<CuotaAdministracion>();
        public ICollection<Parqueadero> Parqueaderos { get; set; } = new List<Parqueadero>();
        public ICollection<Mensajeria> Mensajerias { get; set; } = new List<Mensajeria>();
        public ICollection<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();
        public ICollection<ResidenteUnidad> Residentes { get; set; } = new List<ResidenteUnidad>();
        public ICollection<Ingreso> Ingresos { get; set; } = new List<Ingreso>();
    }
}
