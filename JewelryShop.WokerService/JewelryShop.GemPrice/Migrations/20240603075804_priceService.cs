using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.GemPrice.Migrations
{
    /// <inheritdoc />
    public partial class priceService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gem",
                columns: table => new
                {
                    GemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Carat = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Clarity = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cut = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gem", x => x.GemId);
                });

            migrationBuilder.CreateTable(
                name: "Metal",
                columns: table => new
                {
                    MetalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetalType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Purity = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metal", x => x.MetalId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gem");

            migrationBuilder.DropTable(
                name: "Metal");
        }
    }
}
