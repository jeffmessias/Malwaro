using Microsoft.EntityFrameworkCore.Migrations;

namespace Malwaro.Migrations
{
    public partial class AlterValorFieldType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_Produto_ProdutoId",
                table: "CarrinhoItens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoItens",
                table: "CarrinhoItens");

            migrationBuilder.RenameTable(
                name: "CarrinhoItens",
                newName: "CarrinhoItem");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoItens_ProdutoId",
                table: "CarrinhoItem",
                newName: "IX_CarrinhoItem_ProdutoId");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "PedidoItem",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoItem",
                table: "CarrinhoItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItem_Produto_ProdutoId",
                table: "CarrinhoItem",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItem_Produto_ProdutoId",
                table: "CarrinhoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarrinhoItem",
                table: "CarrinhoItem");

            migrationBuilder.RenameTable(
                name: "CarrinhoItem",
                newName: "CarrinhoItens");

            migrationBuilder.RenameIndex(
                name: "IX_CarrinhoItem_ProdutoId",
                table: "CarrinhoItens",
                newName: "IX_CarrinhoItens_ProdutoId");

            migrationBuilder.AlterColumn<int>(
                name: "Valor",
                table: "PedidoItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarrinhoItens",
                table: "CarrinhoItens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_Produto_ProdutoId",
                table: "CarrinhoItens",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
