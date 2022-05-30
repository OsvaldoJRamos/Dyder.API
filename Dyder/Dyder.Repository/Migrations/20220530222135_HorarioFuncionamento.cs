using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dyder.Repository.Migrations
{
    public partial class HorarioFuncionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorarioFuncionamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DiaSemana = table.Column<int>(type: "int", nullable: false),
                    HoraAbertura = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    HoraFechamento = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    EstabelecimentoId = table.Column<long>(type: "bigint", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModificadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeletadoEm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EstaAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioFuncionamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorarioFuncionamento_Estabelecimento_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioFuncionamento_EstabelecimentoId",
                table: "HorarioFuncionamento",
                column: "EstabelecimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioFuncionamento");
        }
    }
}
