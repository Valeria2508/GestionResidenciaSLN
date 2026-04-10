using Microsoft.EntityFrameworkCore;
using GestionResidenciaApi.Models;

namespace GestionResidenciaApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Apartamentos> Apartamentos { get; set; }
        public DbSet<AuditoriaLogin> AuditoriaLogin { get; set; }
        public DbSet<BitacoraVigilancia> BitacoraVigilancia { get; set; }
        public DbSet<Conjunto> Conjunto { get; set; }
        public DbSet<CuotaAdministracion> CuotaAdministracion { get; set; }
        public DbSet<EstadoCuota> EstadoCuota { get; set; }
        public DbSet<EstadoParqueadero> EstadoParqueadero { get; set; }
        public DbSet<Ingreso> Ingreso { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Mensajeria> Mensajeria { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<PagoDetalle> PagoDetalle { get; set; }
        public DbSet<Parqueadero> Parqueadero { get; set; }
        public DbSet<ParqueaderoVisitante> ParqueaderoVisitante { get; set; }
        public DbSet<Permiso> Permiso { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<ResidenteUnidad> ResidenteUnidad { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolPermiso> RolPermiso { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<TipoIngreso> TipoIngreso { get; set; }
        public DbSet<TipoMantenimiento> TipoMantenimiento { get; set; }
        public DbSet<TipoParqueadero> TipoParqueadero { get; set; }
        public DbSet<Torre> Torre { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Visitante> Visitante { get; set; }
        public DbSet<ZonaComun> ZonaComun { get; set; }
    }
}



