using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionResidenciaApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conjunto",
                columns: table => new
                {
                    ConjuntoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conjunto", x => x.ConjuntoId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEstado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "MetodoPago",
                columns: table => new
                {
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodoPago", x => x.MetodoPagoId);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    PermisoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.PermisoId);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "TipoEvento",
                columns: table => new
                {
                    TipoEventoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEvento", x => x.TipoEventoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIngreso",
                columns: table => new
                {
                    TipoIngresoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIngreso", x => x.TipoIngresoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoMantenimiento",
                columns: table => new
                {
                    TipoMantenimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMantenimiento", x => x.TipoMantenimientoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoParqueadero",
                columns: table => new
                {
                    TipoParqueaderoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoParqueadero", x => x.TipoParqueaderoId);
                });

            migrationBuilder.CreateTable(
                name: "Visitante",
                columns: table => new
                {
                    VisitanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitante", x => x.VisitanteId);
                });

            migrationBuilder.CreateTable(
                name: "Torre",
                columns: table => new
                {
                    TorreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConjuntoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torre", x => x.TorreId);
                    table.ForeignKey(
                        name: "FK_Torre_Conjunto_ConjuntoId",
                        column: x => x.ConjuntoId,
                        principalTable: "Conjunto",
                        principalColumn: "ConjuntoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZonaComun",
                columns: table => new
                {
                    ZonaComunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConjuntoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    RequierePago = table.Column<bool>(type: "bit", nullable: false),
                    ValorHora = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZonaComun", x => x.ZonaComunId);
                    table.ForeignKey(
                        name: "FK_ZonaComun_Conjunto_ConjuntoId",
                        column: x => x.ConjuntoId,
                        principalTable: "Conjunto",
                        principalColumn: "ConjuntoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermisoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermiso", x => new { x.RolId, x.PermisoId });
                    table.ForeignKey(
                        name: "FK_RolPermiso_Permiso_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permiso",
                        principalColumn: "PermisoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "PersonaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apartamentos",
                columns: table => new
                {
                    UnidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TorreId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartamentos", x => x.UnidadId);
                    table.ForeignKey(
                        name: "FK_Apartamentos_Torre_TorreId",
                        column: x => x.TorreId,
                        principalTable: "Torre",
                        principalColumn: "TorreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaLogin",
                columns: table => new
                {
                    AuditoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaIntento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exitoso = table.Column<bool>(type: "bit", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaLogin", x => x.AuditoriaId);
                    table.ForeignKey(
                        name: "FK_AuditoriaLogin_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    PagoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    MetodoPagoId = table.Column<int>(type: "int", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PagoObservacionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.PagoId);
                    table.ForeignKey(
                        name: "FK_Pago_MetodoPago_MetodoPagoId",
                        column: x => x.MetodoPagoId,
                        principalTable: "MetodoPago",
                        principalColumn: "MetodoPagoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    ReservaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonaComunId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.ReservaId);
                    table.ForeignKey(
                        name: "FK_Reserva_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reserva_ZonaComun_ZonaComunId",
                        column: x => x.ZonaComunId,
                        principalTable: "ZonaComun",
                        principalColumn: "ZonaComunId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuotaAdministracion",
                columns: table => new
                {
                    CuotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Periodo = table.Column<DateOnly>(type: "date", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SaldoPendiente = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotaAdministracion", x => x.CuotaId);
                    table.ForeignKey(
                        name: "FK_CuotaAdministracion_Apartamentos_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Apartamentos",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuotaAdministracion_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    IngresoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIngresoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    VisitanteId = table.Column<int>(type: "int", nullable: false),
                    NombrePersona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHoraIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.IngresoId);
                    table.ForeignKey(
                        name: "FK_Ingreso_Apartamentos_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Apartamentos",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingreso_TipoIngreso_TipoIngresoId",
                        column: x => x.TipoIngresoId,
                        principalTable: "TipoIngreso",
                        principalColumn: "TipoIngresoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingreso_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingreso_Visitante_VisitanteId",
                        column: x => x.VisitanteId,
                        principalTable: "Visitante",
                        principalColumn: "VisitanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mantenimiento",
                columns: table => new
                {
                    MantenimientoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMantenimientoId = table.Column<int>(type: "int", nullable: false),
                    ZonaComunId = table.Column<int>(type: "int", nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Proveedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mantenimiento", x => x.MantenimientoId);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_Apartamentos_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Apartamentos",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_TipoMantenimiento_TipoMantenimientoId",
                        column: x => x.TipoMantenimientoId,
                        principalTable: "TipoMantenimiento",
                        principalColumn: "TipoMantenimientoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mantenimiento_ZonaComun_ZonaComunId",
                        column: x => x.ZonaComunId,
                        principalTable: "ZonaComun",
                        principalColumn: "ZonaComunId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensajeria",
                columns: table => new
                {
                    MensajeriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Guia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRecepcion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensajeria", x => x.MensajeriaId);
                    table.ForeignKey(
                        name: "FK_Mensajeria_Apartamentos_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Apartamentos",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mensajeria_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parqueadero",
                columns: table => new
                {
                    ParqueaderoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    TipoParqueaderoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parqueadero", x => x.ParqueaderoId);
                    table.ForeignKey(
                        name: "FK_Parqueadero_Apartamentos_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Apartamentos",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parqueadero_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parqueadero_TipoParqueadero_TipoParqueaderoId",
                        column: x => x.TipoParqueaderoId,
                        principalTable: "TipoParqueadero",
                        principalColumn: "TipoParqueaderoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResidenteUnidad",
                columns: table => new
                {
                    ResidenteUnidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    EsPropietario = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidenteUnidad", x => x.ResidenteUnidadId);
                    table.ForeignKey(
                        name: "FK_ResidenteUnidad_Apartamentos_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Apartamentos",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidenteUnidad_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PagoDetalle",
                columns: table => new
                {
                    PagoDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PagoId = table.Column<int>(type: "int", nullable: false),
                    CuotaId = table.Column<int>(type: "int", nullable: false),
                    ValorAbonado = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagoDetalle", x => x.PagoDetalleId);
                    table.ForeignKey(
                        name: "FK_PagoDetalle_CuotaAdministracion_CuotaId",
                        column: x => x.CuotaId,
                        principalTable: "CuotaAdministracion",
                        principalColumn: "CuotaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PagoDetalle_Pago_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pago",
                        principalColumn: "PagoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BitacoraVigilancia",
                columns: table => new
                {
                    BitacoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VigilanteId = table.Column<int>(type: "int", nullable: false),
                    TipoEventoId = table.Column<int>(type: "int", nullable: false),
                    IngresoId = table.Column<int>(type: "int", nullable: false),
                    UnidadId = table.Column<int>(type: "int", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitacoraVigilancia", x => x.BitacoraId);
                    table.ForeignKey(
                        name: "FK_BitacoraVigilancia_Apartamentos_UnidadId",
                        column: x => x.UnidadId,
                        principalTable: "Apartamentos",
                        principalColumn: "UnidadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BitacoraVigilancia_Ingreso_IngresoId",
                        column: x => x.IngresoId,
                        principalTable: "Ingreso",
                        principalColumn: "IngresoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BitacoraVigilancia_TipoEvento_TipoEventoId",
                        column: x => x.TipoEventoId,
                        principalTable: "TipoEvento",
                        principalColumn: "TipoEventoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BitacoraVigilancia_Usuario_VigilanteId",
                        column: x => x.VigilanteId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParqueaderoVisitante",
                columns: table => new
                {
                    ParqueaderoVisitanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParqueaderoId = table.Column<int>(type: "int", nullable: false),
                    IngresoId = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHoraIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitanteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParqueaderoVisitante", x => x.ParqueaderoVisitanteId);
                    table.ForeignKey(
                        name: "FK_ParqueaderoVisitante_Ingreso_IngresoId",
                        column: x => x.IngresoId,
                        principalTable: "Ingreso",
                        principalColumn: "IngresoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParqueaderoVisitante_Parqueadero_ParqueaderoId",
                        column: x => x.ParqueaderoId,
                        principalTable: "Parqueadero",
                        principalColumn: "ParqueaderoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ParqueaderoVisitante_Visitante_VisitanteId",
                        column: x => x.VisitanteId,
                        principalTable: "Visitante",
                        principalColumn: "VisitanteId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartamentos_TorreId",
                table: "Apartamentos",
                column: "TorreId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaLogin_UsuarioId",
                table: "AuditoriaLogin",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraVigilancia_IngresoId",
                table: "BitacoraVigilancia",
                column: "IngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraVigilancia_TipoEventoId",
                table: "BitacoraVigilancia",
                column: "TipoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraVigilancia_UnidadId",
                table: "BitacoraVigilancia",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_BitacoraVigilancia_VigilanteId",
                table: "BitacoraVigilancia",
                column: "VigilanteId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotaAdministracion_EstadoId",
                table: "CuotaAdministracion",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuotaAdministracion_UnidadId",
                table: "CuotaAdministracion",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_TipoIngresoId",
                table: "Ingreso",
                column: "TipoIngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_UnidadId",
                table: "Ingreso",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_UsuarioId",
                table: "Ingreso",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingreso_VisitanteId",
                table: "Ingreso",
                column: "VisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_TipoMantenimientoId",
                table: "Mantenimiento",
                column: "TipoMantenimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_UnidadId",
                table: "Mantenimiento",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Mantenimiento_ZonaComunId",
                table: "Mantenimiento",
                column: "ZonaComunId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajeria_UnidadId",
                table: "Mensajeria",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensajeria_UsuarioId",
                table: "Mensajeria",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_MetodoPagoId",
                table: "Pago",
                column: "MetodoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_UsuarioId",
                table: "Pago",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalle_CuotaId",
                table: "PagoDetalle",
                column: "CuotaId");

            migrationBuilder.CreateIndex(
                name: "IX_PagoDetalle_PagoId",
                table: "PagoDetalle",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parqueadero_EstadoId",
                table: "Parqueadero",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parqueadero_TipoParqueaderoId",
                table: "Parqueadero",
                column: "TipoParqueaderoId");

            migrationBuilder.CreateIndex(
                name: "IX_Parqueadero_UnidadId",
                table: "Parqueadero",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ParqueaderoVisitante_IngresoId",
                table: "ParqueaderoVisitante",
                column: "IngresoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParqueaderoVisitante_ParqueaderoId",
                table: "ParqueaderoVisitante",
                column: "ParqueaderoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParqueaderoVisitante_VisitanteId",
                table: "ParqueaderoVisitante",
                column: "VisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_EstadoId",
                table: "Reserva",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_UsuarioId",
                table: "Reserva",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ZonaComunId",
                table: "Reserva",
                column: "ZonaComunId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidenteUnidad_UnidadId",
                table: "ResidenteUnidad",
                column: "UnidadId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidenteUnidad_UsuarioId",
                table: "ResidenteUnidad",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_PermisoId",
                table: "RolPermiso",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_Torre_ConjuntoId",
                table: "Torre",
                column: "ConjuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PersonaId",
                table: "Usuario",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_ZonaComun_ConjuntoId",
                table: "ZonaComun",
                column: "ConjuntoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditoriaLogin");

            migrationBuilder.DropTable(
                name: "BitacoraVigilancia");

            migrationBuilder.DropTable(
                name: "Mantenimiento");

            migrationBuilder.DropTable(
                name: "Mensajeria");

            migrationBuilder.DropTable(
                name: "PagoDetalle");

            migrationBuilder.DropTable(
                name: "ParqueaderoVisitante");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "ResidenteUnidad");

            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "TipoEvento");

            migrationBuilder.DropTable(
                name: "TipoMantenimiento");

            migrationBuilder.DropTable(
                name: "CuotaAdministracion");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Ingreso");

            migrationBuilder.DropTable(
                name: "Parqueadero");

            migrationBuilder.DropTable(
                name: "ZonaComun");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "MetodoPago");

            migrationBuilder.DropTable(
                name: "TipoIngreso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Visitante");

            migrationBuilder.DropTable(
                name: "Apartamentos");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "TipoParqueadero");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Torre");

            migrationBuilder.DropTable(
                name: "Conjunto");
        }
    }
}
