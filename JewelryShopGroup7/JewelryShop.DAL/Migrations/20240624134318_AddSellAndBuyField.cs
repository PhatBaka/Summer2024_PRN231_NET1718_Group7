using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSellAndBuyField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Material",
                newName: "SellPrice");

            migrationBuilder.RenameColumn(
                name: "InitialPrice",
                table: "Material",
                newName: "CurrentPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "BuyPrice",
                table: "Material",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
               name: "CreatedDate",
               table: "Material");


            migrationBuilder.AddColumn<String>(
               name: "MaterialStatus",
               table: "Material",
               nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "Material");

            migrationBuilder.RenameColumn(
                name: "SellPrice",
                table: "Material",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "CurrentPrice",
                table: "Material",
                newName: "InitialPrice");
        }
    }
}
