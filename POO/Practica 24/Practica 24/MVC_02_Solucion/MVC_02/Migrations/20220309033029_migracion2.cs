using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_02.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Reservacion_ReservacionId",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_ReservacionId",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "ReservacionId",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Apeliidos",
                table: "Cliente",
                newName: "Apellidos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "Cliente",
                newName: "Apeliidos");

            migrationBuilder.AddColumn<int>(
                name: "ReservacionId",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ReservacionId",
                table: "Cliente",
                column: "ReservacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Reservacion_ReservacionId",
                table: "Cliente",
                column: "ReservacionId",
                principalTable: "Reservacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
