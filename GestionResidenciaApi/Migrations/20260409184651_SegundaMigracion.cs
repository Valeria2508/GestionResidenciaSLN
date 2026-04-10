using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionResidenciaApi.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Capacidad",
                table: "ZonaComun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConjuntoId",
                table: "ZonaComun",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "ZonaComun",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "RequierePago",
                table: "ZonaComun",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorHora",
                table: "ZonaComun",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Visitante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Visitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Usuario",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RolId",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ConjuntoId",
                table: "Torre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Torre",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TipoParqueadero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TipoMantenimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TipoIngreso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "TipoEvento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PermisoId",
                table: "RolPermiso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Rol",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EsPropietario",
                table: "ResidenteUnidad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "ResidenteUnidad",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicio",
                table: "ResidenteUnidad",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "ResidenteUnidad",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "ResidenteUnidad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "ResidenteUnidad",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoReservaId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Reserva",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraFin",
                table: "Reserva",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraInicio",
                table: "Reserva",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Reserva",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZonaComunId",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Correo",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroDocumento",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "Persona",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Permiso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHoraIngreso",
                table: "ParqueaderoVisitante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHoraSalida",
                table: "ParqueaderoVisitante",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IngresoId",
                table: "ParqueaderoVisitante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParqueaderoId",
                table: "ParqueaderoVisitante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "ParqueaderoVisitante",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstadoParqueaderoId",
                table: "Parqueadero",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Parqueadero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoParqueaderoId",
                table: "Parqueadero",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "Parqueadero",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CuotaId",
                table: "PagoDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PagoId",
                table: "PagoDetalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorAbonado",
                table: "PagoDetalle",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaPago",
                table: "Pago",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MetodoPagoId",
                table: "Pago",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PagoObservacionId",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Pago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Pago",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Pago",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "MetodoPago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "MetodoPago",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Mensajeria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Empresa",
                table: "Mensajeria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrega",
                table: "Mensajeria",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRecepcion",
                table: "Mensajeria",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Guia",
                table: "Mensajeria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "Mensajeria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Mensajeria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Costo",
                table: "Mantenimiento",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Mantenimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Mantenimiento",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Proveedor",
                table: "Mantenimiento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoMantenimientoId",
                table: "Mantenimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "Mantenimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZonaComunId",
                table: "Mantenimiento",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "Ingreso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHoraIngreso",
                table: "Ingreso",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHoraSalida",
                table: "Ingreso",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NombrePersona",
                table: "Ingreso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Ingreso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoIngresoId",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Vehiculo",
                table: "Ingreso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VisitanteId",
                table: "Ingreso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "EstadoParqueadero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "EstadoParqueadero",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "EmpleEstadoCuotaado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EstadoCuotaId",
                table: "CuotaAdministracion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaLimite",
                table: "CuotaAdministracion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "CuotaAdministracion",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Periodo",
                table: "CuotaAdministracion",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaldoPendiente",
                table: "CuotaAdministracion",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "CuotaAdministracion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valor",
                table: "CuotaAdministracion",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Conjunto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Conjunto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NIT",
                table: "Conjunto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Conjunto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Conjunto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaHora",
                table: "BitacoraVigilancia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IngresoId",
                table: "BitacoraVigilancia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "BitacoraVigilancia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TipoEventoId",
                table: "BitacoraVigilancia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnidadId",
                table: "BitacoraVigilancia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VigilanteId",
                table: "BitacoraVigilancia",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Exitoso",
                table: "AuditoriaLogin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaIntento",
                table: "AuditoriaLogin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Ip",
                table: "AuditoriaLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Motivo",
                table: "AuditoriaLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AuditoriaLogin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "AuditoriaLogin",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "Apartamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Apartamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Apartamentos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TorreId",
                table: "Apartamentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacidad",
                table: "ZonaComun");

            migrationBuilder.DropColumn(
                name: "ConjuntoId",
                table: "ZonaComun");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "ZonaComun");

            migrationBuilder.DropColumn(
                name: "RequierePago",
                table: "ZonaComun");

            migrationBuilder.DropColumn(
                name: "ValorHora",
                table: "ZonaComun");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Visitante");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "RolId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ConjuntoId",
                table: "Torre");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Torre");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TipoParqueadero");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TipoMantenimiento");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TipoIngreso");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "TipoEvento");

            migrationBuilder.DropColumn(
                name: "PermisoId",
                table: "RolPermiso");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "EsPropietario",
                table: "ResidenteUnidad");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "ResidenteUnidad");

            migrationBuilder.DropColumn(
                name: "FechaInicio",
                table: "ResidenteUnidad");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "ResidenteUnidad");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "ResidenteUnidad");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "ResidenteUnidad");

            migrationBuilder.DropColumn(
                name: "EstadoReservaId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "HoraFin",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "HoraInicio",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ZonaComunId",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "Correo",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "NumeroDocumento",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Permiso");

            migrationBuilder.DropColumn(
                name: "FechaHoraIngreso",
                table: "ParqueaderoVisitante");

            migrationBuilder.DropColumn(
                name: "FechaHoraSalida",
                table: "ParqueaderoVisitante");

            migrationBuilder.DropColumn(
                name: "IngresoId",
                table: "ParqueaderoVisitante");

            migrationBuilder.DropColumn(
                name: "ParqueaderoId",
                table: "ParqueaderoVisitante");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "ParqueaderoVisitante");

            migrationBuilder.DropColumn(
                name: "EstadoParqueaderoId",
                table: "Parqueadero");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Parqueadero");

            migrationBuilder.DropColumn(
                name: "TipoParqueaderoId",
                table: "Parqueadero");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "Parqueadero");

            migrationBuilder.DropColumn(
                name: "CuotaId",
                table: "PagoDetalle");

            migrationBuilder.DropColumn(
                name: "PagoId",
                table: "PagoDetalle");

            migrationBuilder.DropColumn(
                name: "ValorAbonado",
                table: "PagoDetalle");

            migrationBuilder.DropColumn(
                name: "FechaPago",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "MetodoPagoId",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "PagoObservacionId",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pago");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "MetodoPago");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "MetodoPago");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Mensajeria");

            migrationBuilder.DropColumn(
                name: "Empresa",
                table: "Mensajeria");

            migrationBuilder.DropColumn(
                name: "FechaEntrega",
                table: "Mensajeria");

            migrationBuilder.DropColumn(
                name: "FechaRecepcion",
                table: "Mensajeria");

            migrationBuilder.DropColumn(
                name: "Guia",
                table: "Mensajeria");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "Mensajeria");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Mensajeria");

            migrationBuilder.DropColumn(
                name: "Costo",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "Proveedor",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "TipoMantenimientoId",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "ZonaComunId",
                table: "Mantenimiento");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "FechaHoraIngreso",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "FechaHoraSalida",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "NombrePersona",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "TipoIngresoId",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "Vehiculo",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "VisitanteId",
                table: "Ingreso");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "EstadoParqueadero");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "EstadoParqueadero");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "EmpleEstadoCuotaado");

            migrationBuilder.DropColumn(
                name: "EstadoCuotaId",
                table: "CuotaAdministracion");

            migrationBuilder.DropColumn(
                name: "FechaLimite",
                table: "CuotaAdministracion");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "CuotaAdministracion");

            migrationBuilder.DropColumn(
                name: "Periodo",
                table: "CuotaAdministracion");

            migrationBuilder.DropColumn(
                name: "SaldoPendiente",
                table: "CuotaAdministracion");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "CuotaAdministracion");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "CuotaAdministracion");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Conjunto");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Conjunto");

            migrationBuilder.DropColumn(
                name: "NIT",
                table: "Conjunto");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Conjunto");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Conjunto");

            migrationBuilder.DropColumn(
                name: "FechaHora",
                table: "BitacoraVigilancia");

            migrationBuilder.DropColumn(
                name: "IngresoId",
                table: "BitacoraVigilancia");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "BitacoraVigilancia");

            migrationBuilder.DropColumn(
                name: "TipoEventoId",
                table: "BitacoraVigilancia");

            migrationBuilder.DropColumn(
                name: "UnidadId",
                table: "BitacoraVigilancia");

            migrationBuilder.DropColumn(
                name: "VigilanteId",
                table: "BitacoraVigilancia");

            migrationBuilder.DropColumn(
                name: "Exitoso",
                table: "AuditoriaLogin");

            migrationBuilder.DropColumn(
                name: "FechaIntento",
                table: "AuditoriaLogin");

            migrationBuilder.DropColumn(
                name: "Ip",
                table: "AuditoriaLogin");

            migrationBuilder.DropColumn(
                name: "Motivo",
                table: "AuditoriaLogin");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AuditoriaLogin");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "AuditoriaLogin");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Apartamentos");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Apartamentos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Apartamentos");

            migrationBuilder.DropColumn(
                name: "TorreId",
                table: "Apartamentos");
        }
    }
}
