using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dyder.Repository.Migrations
{
    public partial class fechadoAbertoTemporariamente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AbertoAte",
                table: "Estabelecimento",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechadoAte",
                table: "Estabelecimento",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbertoAte",
                table: "Estabelecimento");

            migrationBuilder.DropColumn(
                name: "FechadoAte",
                table: "Estabelecimento");
        }
    }
}
