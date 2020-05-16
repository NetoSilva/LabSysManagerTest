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
                    TipoSanguineo = table.Column<string>(nullable: false),
                    Cor = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Altura", "Celular", "Cep", "Cidade", "Cor", "Cpf", "DataNasc", "Email", "Estado", "Idade", "Mae", "Nome", "Numero", "Pai", "Peso", "Rg", "Senha", "Signo", "TelefoneFixo", "TipoSanguineo" },
                values: new object[] { new Guid("b9feed95-8b58-4a13-8873-226499232776"), "1,73", "(34) 99963-1139", "38183-044", "Araxá", "Vermelho", "837.218.376-73", new DateTime(2001, 2, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "levijuanhenriquedarosa_@cmfcequipamentos.com.br", "MG", 18L, "Giovanna Bianca Cristiane", "Levi Juan Henrique da Rosa", 715L, "Hugo Antonio Roberto da Rosa", 78L, "33.171.161-8", "jqAYDrlOk5", "Peixes", "(34) 3670-2306", "ANegativo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
