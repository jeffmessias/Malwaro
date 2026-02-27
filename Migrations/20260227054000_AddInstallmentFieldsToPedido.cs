using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Malwaro.Migrations
{
    /// <inheritdoc />
    public partial class AddInstallmentFieldsToPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroParcelas",
                table: "Pedido",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<double>(
                name: "TaxaJuros",
                table: "Pedido",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroParcelas",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "TaxaJuros",
                table: "Pedido");
        }
    }
}
