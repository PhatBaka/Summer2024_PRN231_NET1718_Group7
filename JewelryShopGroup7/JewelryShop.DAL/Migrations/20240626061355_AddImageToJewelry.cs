using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddImageToJewelry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "JewelryImageData",
                table: "Jewelry",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JewelryImageData",
                table: "Jewelry");
        }
    }
}
