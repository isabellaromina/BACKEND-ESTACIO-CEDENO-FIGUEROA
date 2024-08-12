using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto_Final.Migrations
{
    /// <inheritdoc />
    public partial class Inicial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompras_Clientes_ClienteId",
                table: "OrdenCompras");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompras_SolicitudCompras_SolicitudCompraId",
                table: "OrdenCompras");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompras_ClienteId",
                table: "OrdenCompras");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompras_SolicitudCompraId",
                table: "OrdenCompras");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompras_ClienteId",
                table: "OrdenCompras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompras_SolicitudCompraId",
                table: "OrdenCompras",
                column: "SolicitudCompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompras_Clientes_ClienteId",
                table: "OrdenCompras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompras_SolicitudCompras_SolicitudCompraId",
                table: "OrdenCompras",
                column: "SolicitudCompraId",
                principalTable: "SolicitudCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
