using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionResidenciaApi.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Estado> Estados { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartamentos>()
                .HasOne(a => a.Torre)
                .WithMany(t => t.Apartamentos)
                .HasForeignKey(a => a.TorreId);

            modelBuilder.Entity<CuotaAdministracion>()
                .HasOne(c => c.Estado)
                .WithMany(e => e.Cuotas)
                .HasForeignKey(c => c.EstadoId);

            modelBuilder.Entity<CuotaAdministracion>()
                .HasOne(c => c.Unidad)
                .WithMany(u => u.Cuotas)
                .HasForeignKey(c => c.UnidadId);

            modelBuilder.Entity<Parqueadero>()
                .HasOne(p => p.Unidad)
                .WithMany(u => u.Parqueaderos)
                .HasForeignKey(p => p.UnidadId);

            modelBuilder.Entity<Parqueadero>()
                .HasOne(p => p.TipoParqueadero)
                .WithMany(t => t.Parqueaderos)
                .HasForeignKey(p => p.TipoParqueaderoId);

            modelBuilder.Entity<Parqueadero>()
                .HasOne(p => p.Estado)
                .WithMany(e => e.Parqueaderos)
                .HasForeignKey(p => p.EstadoId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.ZonaComun)
                .WithMany(z => z.Reservas)
                .HasForeignKey(r => r.ZonaComunId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Estado)
                .WithMany(e => e.Reservas)
                .HasForeignKey(r => r.EstadoId);

            modelBuilder.Entity<ZonaComun>()
                .HasOne(z => z.Conjunto)
                .WithMany(c => c.ZonasComunes)
                .HasForeignKey(z => z.ConjuntoId);

            modelBuilder.Entity<Torre>()
                .HasOne(t => t.Conjunto)
                .WithMany(c => c.Torres)
                .HasForeignKey(t => t.ConjuntoId);

            modelBuilder.Entity<Mensajeria>()
                .HasOne(m => m.Unidad)
                .WithMany(u => u.Mensajerias)
                .HasForeignKey(m => m.UnidadId);

            modelBuilder.Entity<Mensajeria>()
                .HasOne(m => m.Usuario)
                .WithMany(u => u.Mensajerias)
                .HasForeignKey(m => m.UsuarioId);

            modelBuilder.Entity<Mantenimiento>()
                .HasOne(m => m.TipoMantenimiento)
                .WithMany(t => t.Mantenimientos)
                .HasForeignKey(m => m.TipoMantenimientoId);

            modelBuilder.Entity<Mantenimiento>()
                .HasOne(m => m.ZonaComun)
                .WithMany(z => z.Mantenimientos)
                .HasForeignKey(m => m.ZonaComunId);

            modelBuilder.Entity<Mantenimiento>()
                .HasOne(m => m.Unidad)
                .WithMany(u => u.Mantenimientos)
                .HasForeignKey(m => m.UnidadId);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Pagos)
                .HasForeignKey(p => p.UsuarioId);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.MetodoPago)
                .WithMany(m => m.Pagos)
                .HasForeignKey(p => p.MetodoPagoId);

            modelBuilder.Entity<PagoDetalle>()
                .HasOne(pd => pd.Pago)
                .WithMany(p => p.PagoDetalles)
                .HasForeignKey(pd => pd.PagoId);

            modelBuilder.Entity<PagoDetalle>()
                .HasOne(pd => pd.Cuota)
                .WithMany(c => c.PagoDetalles)
                .HasForeignKey(pd => pd.CuotaId);

            modelBuilder.Entity<ResidenteUnidad>()
                .HasOne(ru => ru.Usuario)
                .WithMany(u => u.ResidenteUnidades)
                .HasForeignKey(ru => ru.UsuarioId);

            modelBuilder.Entity<ResidenteUnidad>()
                .HasOne(ru => ru.Unidad)
                .WithMany(u => u.Residentes)
                .HasForeignKey(ru => ru.UnidadId);

            modelBuilder.Entity<AuditoriaLogin>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Auditorias)
                .HasForeignKey(a => a.UsuarioId);

            modelBuilder.Entity<Ingreso>()
                .HasOne(i => i.TipoIngreso)
                .WithMany(t => t.Ingresos)
                .HasForeignKey(i => i.TipoIngresoId);

            modelBuilder.Entity<Ingreso>()
                .HasOne(i => i.Usuario)
                .WithMany(u => u.Ingresos)
                .HasForeignKey(i => i.UsuarioId);

            modelBuilder.Entity<Ingreso>()
                .HasOne(i => i.Unidad)
                .WithMany(u => u.Ingresos)
                .HasForeignKey(i => i.UnidadId);

            modelBuilder.Entity<Ingreso>()
                .HasOne(i => i.Visitante)
                .WithMany(v => v.Ingresos)
                .HasForeignKey(i => i.VisitanteId);

            modelBuilder.Entity<BitacoraVigilancia>()
                .HasOne(b => b.Vigilante)
                .WithMany(u => u.Vigilancias)
                .HasForeignKey(b => b.VigilanteId);

            modelBuilder.Entity<BitacoraVigilancia>()
                .HasOne(b => b.TipoEvento)
                .WithMany(t => t.Bitacoras)
                .HasForeignKey(b => b.TipoEventoId);

            modelBuilder.Entity<BitacoraVigilancia>()
                .HasOne(b => b.Ingreso)
                .WithMany(i => i.Bitacoras)
                .HasForeignKey(b => b.IngresoId);

            modelBuilder.Entity<ParqueaderoVisitante>()
                .HasOne(pv => pv.Parqueadero)
                .WithMany(p => p.ParqueaderoVisitantes)
                .HasForeignKey(pv => pv.ParqueaderoId);

            modelBuilder.Entity<ParqueaderoVisitante>()
                .HasOne(pv => pv.Ingreso)
                .WithMany(i => i.ParqueaderoVisitantes)
                .HasForeignKey(pv => pv.IngresoId);

            modelBuilder.Entity<RolPermiso>()
                .HasKey(rp => new { rp.RolId, rp.PermisoId });

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Rol)
                .WithMany(r => r.RolPermisos)
                .HasForeignKey(rp => rp.RolId);

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Permiso)
                .WithMany(p => p.RolPermisos)
                .HasForeignKey(rp => rp.PermisoId);
        }
    }
}



