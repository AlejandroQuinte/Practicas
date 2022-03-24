using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_02.Migrations
{
    public partial class migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reservacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaReservacionInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaReservacionFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apeliidos = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DireccionExacta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReservacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Reservacion_ReservacionId",
                        column: x => x.ReservacionId,
                        principalTable: "Reservacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_ReservacionId",
                table: "Cliente",
                column: "ReservacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacion_ClienteId",
                table: "Reservacion",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservacion_Cliente_ClienteId",
                table: "Reservacion",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Reservacion_ReservacionId",
                table: "Cliente");

            migrationBuilder.DropTable(
                name: "Reservacion");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
