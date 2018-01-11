using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BigBang.Dados.Migrations
{
    public partial class Personagem_Index_IsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personagens_Nome",
                table: "Personagens");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_Nome",
                table: "Personagens",
                column: "Nome",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Personagens_Nome",
                table: "Personagens");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_Nome",
                table: "Personagens",
                column: "Nome");
        }
    }
}
