using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutri.Infrastructure.Migrations
{
    public partial class Cambioid2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ListaId",
                table: "ListasSuplementosPersonalizada",
                newName: "IdListaa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdListaa",
                table: "ListasSuplementosPersonalizada",
                newName: "ListaId");
        }
    }
}
