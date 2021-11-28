using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Malwaro.Migrations
{
    public partial class PedidoUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pedido",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "NovoUsuarioViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordConfirm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoRua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoBairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoCidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoUF = table.Column<int>(type: "int", nullable: false),
                    EnderecoCEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnderecoNumero = table.Column<int>(type: "int", nullable: false),
                    EnderecoComplemento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NovoUsuarioViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_UserId",
                table: "Pedido",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_AspNetUsers_UserId",
                table: "Pedido",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_AspNetUsers_UserId",
                table: "Pedido");

            migrationBuilder.DropTable(
                name: "NovoUsuarioViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_UserId",
                table: "Pedido");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
