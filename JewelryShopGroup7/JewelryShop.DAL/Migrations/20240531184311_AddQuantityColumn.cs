using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Jewelry",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Jewelry");
        }
    }
}
