using Microsoft.EntityFrameworkCore.Migrations;

namespace AspCepAPI.Migrations
{
    public partial class TesteMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CepModel",
                columns: table => new
                {
                    cep = table.Column<string>(nullable: false),
                    logradouro = table.Column<string>(nullable: true),
                    complemento = table.Column<string>(nullable: true),
                    bairro = table.Column<string>(nullable: true),
                    localidade = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true),
                    unidade = table.Column<string>(nullable: true),
                    ibge = table.Column<string>(nullable: true),
                    gia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CepModel", x => x.cep);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CepModel");
        }
    }
}
