using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionResidenciaApi.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParqueaderoVisitante_Ingreso_IngresoId",
                table: "ParqueaderoVisitante");

            migrationBuilder.DropForeignKey(
                name: "FK_ParqueaderoVisitante_Parqueadero_ParqueaderoId",
                table: "ParqueaderoVisitante");

            migrationBuilder.AddForeignKey(
                name: "FK_ParqueaderoVisitante_Ingreso_IngresoId",
                table: "ParqueaderoVisitante",
                column: "IngresoId",
                principalTable: "Ingreso",
                principalColumn: "IngresoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParqueaderoVisitante_Parqueadero_ParqueaderoId",
                table: "ParqueaderoVisitante",
                column: "ParqueaderoId",
                principalTable: "Parqueadero",
                principalColumn: "ParqueaderoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParqueaderoVisitante_Ingreso_IngresoId",
                table: "ParqueaderoVisitante");

            migrationBuilder.DropForeignKey(
                name: "FK_ParqueaderoVisitante_Parqueadero_ParqueaderoId",
                table: "ParqueaderoVisitante");

            migrationBuilder.AddForeignKey(
                name: "FK_ParqueaderoVisitante_Ingreso_IngresoId",
                table: "ParqueaderoVisitante",
                column: "IngresoId",
                principalTable: "Ingreso",
                principalColumn: "IngresoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParqueaderoVisitante_Parqueadero_ParqueaderoId",
                table: "ParqueaderoVisitante",
                column: "ParqueaderoId",
                principalTable: "Parqueadero",
                principalColumn: "ParqueaderoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
