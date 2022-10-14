using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutri.Infrastructure.Migrations
{
    public partial class Agregaridyquitarrenglon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdListaa",
                table: "ListasSuplementosPersonalizada",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "ListasSuplementosPersonalizada",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "ListasSuplementosPersonalizada");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ListasSuplementosPersonalizada",
                newName: "IdListaa");
        }
    }
}
