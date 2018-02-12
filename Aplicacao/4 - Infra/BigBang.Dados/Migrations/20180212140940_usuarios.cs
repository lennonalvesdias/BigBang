using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BigBang.Dados.Migrations
{
    public partial class usuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personagens_Nome",
                table: "Personagens");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Apelido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    DataAtualizacaoRegistro = table.Column<DateTime>(nullable: false),
                    DataCriacaoRegistro = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_Nome",
                table: "Personagens",
                column: "Nome",
                unique: true);
        }
    }
}
