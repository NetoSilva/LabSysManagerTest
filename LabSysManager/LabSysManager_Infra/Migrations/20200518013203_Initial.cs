using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabSysManager_Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Idade = table.Column<long>(nullable: false),
                    Cpf = table.Column<string>(nullable: true),
                    Rg = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Signo = table.Column<string>(nullable: true),
                    Mae = table.Column<string>(nullable: true),
                    Pai = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Numero = table.Column<long>(nullable: false),
                    TelefoneFixo = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Altura = table.Column<string>(nullable: true),
                    Peso = table.Column<long>(nullable: false),
                    TipoSanguineo = table.Column<string>(nullable: true),
                    Cor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
