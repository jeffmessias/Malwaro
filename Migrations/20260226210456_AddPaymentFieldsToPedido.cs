using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Malwaro.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentFieldsToPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetodoPagamento",
                table: "Pedido",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Pedido",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetodoPagamento",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pedido");
        }
    }
}
