using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Disrupt.Web.Migrations
{
    public partial class BancoDisrupt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Usuario_Tbl_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Tbl_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Usuario_EnderecoId",
                table: "Tbl_Usuario",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_Usuario");

            migrationBuilder.DropTable(
                name: "Tbl_Endereco");
        }
    }
}
