using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionResidenciaApi.Migrations
{
    /// <inheritdoc />
    public partial class Segunda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_ZonaComun_ZonaComunId",
                table: "Mantenimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimiento_ZonaComun_ZonaComunId",
                table: "Mantenimiento",
                column: "ZonaComunId",
                principalTable: "ZonaComun",
                principalColumn: "ZonaComunId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mantenimiento_ZonaComun_ZonaComunId",
                table: "Mantenimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Mantenimiento_ZonaComun_ZonaComunId",
                table: "Mantenimiento",
                column: "ZonaComunId",
                principalTable: "ZonaComun",
                principalColumn: "ZonaComunId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
