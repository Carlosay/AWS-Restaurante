using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurante.Migrations
{
    /// <inheritdoc />
    public partial class inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Sector_SectorId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Sector_SectorId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sector",
                table: "Sector");

            migrationBuilder.RenameTable(
                name: "Sector",
                newName: "Sectores");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sectores",
                table: "Sectores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Sectores_SectorId",
                table: "Empleados",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Sectores_SectorId",
                table: "Productos",
                column: "SectorId",
                principalTable: "Sectores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Sectores_SectorId",
                table: "Empleados");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Sectores_SectorId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sectores",
                table: "Sectores");

            migrationBuilder.RenameTable(
                name: "Sectores",
                newName: "Sector");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sector",
                table: "Sector",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Sector_SectorId",
                table: "Empleados",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Sector_SectorId",
                table: "Productos",
                column: "SectorId",
                principalTable: "Sector",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
