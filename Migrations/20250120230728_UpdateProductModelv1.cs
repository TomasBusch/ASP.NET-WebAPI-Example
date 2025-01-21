using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductModelv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceInCents",
                table: "Product",
                newName: "Stock");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Product",
                newName: "Discontinued");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Product",
                newName: "PriceInCents");

            migrationBuilder.RenameColumn(
                name: "Discontinued",
                table: "Product",
                newName: "Count");
        }
    }
}
