using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutri.Infrastructure.Migrations
{
    public partial class AgregarListaPersonalizadaSuplesDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionSuplemento",
                table: "ListasSuplementosPersonalizada");

            migrationBuilder.CreateTable(
                name: "ListasSuplementosPersonalizadasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListaPersonalizadaId = table.Column<int>(type: "int", nullable: false),
                    DescripcionSuplemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasSuplementosPersonalizadasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListasSuplementosPersonalizadasDetalle_ListasSuplementosPersonalizada_ListaPersonalizadaId",
                        column: x => x.ListaPersonalizadaId,
                        principalTable: "ListasSuplementosPersonalizada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListasSuplementosPersonalizadasDetalle_ListaPersonalizadaId",
                table: "ListasSuplementosPersonalizadasDetalle",
                column: "ListaPersonalizadaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListasSuplementosPersonalizadasDetalle");

            migrationBuilder.AddColumn<string>(
                name: "DescripcionSuplemento",
                table: "ListasSuplementosPersonalizada",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
