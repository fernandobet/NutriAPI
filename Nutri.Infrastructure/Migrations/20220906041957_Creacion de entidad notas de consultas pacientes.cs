using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutri.Infrastructure.Migrations
{
    public partial class Creaciondeentidadnotasdeconsultaspacientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultasPacientesNotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultaPacienteId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasPacientesNotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultasPacientesNotas_ConsultasPacientes_ConsultaPacienteId",
                        column: x => x.ConsultaPacienteId,
                        principalTable: "ConsultasPacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasPacientesNotas_ConsultaPacienteId",
                table: "ConsultasPacientesNotas",
                column: "ConsultaPacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultasPacientesNotas");
        }
    }
}
