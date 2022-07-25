using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutri.Infrastructure.Migrations
{
    public partial class MigracionInicialNutriApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamiliasAlimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamiliasAlimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListasSuplementosPersonalizada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Renglon = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionSuplemento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasSuplementosPersonalizada", x => new { x.Id, x.Renglon });
                });

            migrationBuilder.CreateTable(
                name: "MedicionesAlimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesAlimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicionesSuplementos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Decripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicionesSuplementos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edad = table.Column<short>(type: "smallint", nullable: false),
                    Estatura = table.Column<short>(type: "smallint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamiliaAlimentoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicionAlimentoId = table.Column<int>(type: "int", nullable: false),
                    Proteina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Carbohidratos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Azucar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lipidos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calorias = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimentos_FamiliasAlimentos_FamiliaAlimentoId",
                        column: x => x.FamiliaAlimentoId,
                        principalTable: "FamiliasAlimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alimentos_MedicionesAlimentos_MedicionAlimentoId",
                        column: x => x.MedicionAlimentoId,
                        principalTable: "MedicionesAlimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suplementos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicionSuplementoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplementos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suplementos_MedicionesSuplementos_MedicionSuplementoId",
                        column: x => x.MedicionSuplementoId,
                        principalTable: "MedicionesSuplementos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasPacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasPacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsultasPacientes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsultasPacientesAlimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RenglonComida = table.Column<int>(type: "int", nullable: false),
                    Comida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroComida = table.Column<short>(type: "smallint", nullable: false),
                    ConsultaPacienteId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultasPacientesAlimentos", x => new { x.Id, x.RenglonComida });
                    table.ForeignKey(
                        name: "FK_ConsultasPacientesAlimentos_ConsultasPacientes_ConsultaPacienteId",
                        column: x => x.ConsultaPacienteId,
                        principalTable: "ConsultasPacientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_FamiliaAlimentoId",
                table: "Alimentos",
                column: "FamiliaAlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_MedicionAlimentoId",
                table: "Alimentos",
                column: "MedicionAlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasPacientes_PacienteId",
                table: "ConsultasPacientes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultasPacientesAlimentos_ConsultaPacienteId",
                table: "ConsultasPacientesAlimentos",
                column: "ConsultaPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Suplementos_MedicionSuplementoId",
                table: "Suplementos",
                column: "MedicionSuplementoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "ConsultasPacientesAlimentos");

            migrationBuilder.DropTable(
                name: "ListasSuplementosPersonalizada");

            migrationBuilder.DropTable(
                name: "Suplementos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "FamiliasAlimentos");

            migrationBuilder.DropTable(
                name: "MedicionesAlimentos");

            migrationBuilder.DropTable(
                name: "ConsultasPacientes");

            migrationBuilder.DropTable(
                name: "MedicionesSuplementos");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
