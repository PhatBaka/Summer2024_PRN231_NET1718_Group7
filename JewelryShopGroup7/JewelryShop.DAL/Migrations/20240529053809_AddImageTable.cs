using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Jewelry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_ImageId",
                table: "Material",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_ImageId",
                table: "Jewelry",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jewelry_Image_ImageId",
                table: "Jewelry",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelry_Image_ImageId",
                table: "Jewelry");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Material_ImageId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Jewelry_ImageId",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Jewelry");
        }
    }
}
