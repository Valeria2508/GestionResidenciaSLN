using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionResidenciaApi.Migrations
{
    /// <inheritdoc />
    public partial class Tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraVigilancia_Ingreso_IngresoId",
                table: "BitacoraVigilancia");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraVigilancia_Ingreso_IngresoId",
                table: "BitacoraVigilancia",
                column: "IngresoId",
                principalTable: "Ingreso",
                principalColumn: "IngresoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitacoraVigilancia_Ingreso_IngresoId",
                table: "BitacoraVigilancia");

            migrationBuilder.AddForeignKey(
                name: "FK_BitacoraVigilancia_Ingreso_IngresoId",
                table: "BitacoraVigilancia",
                column: "IngresoId",
                principalTable: "Ingreso",
                principalColumn: "IngresoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
