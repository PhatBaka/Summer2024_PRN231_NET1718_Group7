using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveJewelryMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__JewelryMa__Jewel__3B75D760",
                table: "JewelryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK__JewelryMa__Mater__3C69FB99",
                table: "JewelryMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK__JewelryM__EC2050C484ACE139",
                table: "JewelryMaterial");

            migrationBuilder.RenameColumn(
                name: "MaterialID",
                table: "JewelryMaterial",
                newName: "MaterialsMaterialId");

            migrationBuilder.RenameColumn(
                name: "JewelryID",
                table: "JewelryMaterial",
                newName: "JewelriesJewelryId");

            migrationBuilder.RenameIndex(
                name: "IX_JewelryMaterial_MaterialId",
                table: "JewelryMaterial",
                newName: "IX_JewelryMaterial_MaterialsMaterialId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JewelryMaterial",
                table: "JewelryMaterial",
                columns: new[] { "JewelriesJewelryId", "MaterialsMaterialId" });

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryMaterial_Jewelry_JewelriesJewelryId",
                table: "JewelryMaterial",
                column: "JewelriesJewelryId",
                principalTable: "Jewelry",
                principalColumn: "JewelryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JewelryMaterial_Material_MaterialsMaterialId",
                table: "JewelryMaterial",
                column: "MaterialsMaterialId",
                principalTable: "Material",
                principalColumn: "MaterialID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JewelryMaterial_Jewelry_JewelriesJewelryId",
                table: "JewelryMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_JewelryMaterial_Material_MaterialsMaterialId",
                table: "JewelryMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JewelryMaterial",
                table: "JewelryMaterial");

            migrationBuilder.RenameColumn(
                name: "MaterialsMaterialId",
                table: "JewelryMaterial",
                newName: "MaterialID");

            migrationBuilder.RenameColumn(
                name: "JewelriesJewelryId",
                table: "JewelryMaterial",
                newName: "JewelryID");

            migrationBuilder.RenameIndex(
                name: "IX_JewelryMaterial_MaterialsMaterialId",
                table: "JewelryMaterial",
                newName: "IX_JewelryMaterial_MaterialID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__JewelryM__EC2050C484ACE139",
                table: "JewelryMaterial",
                columns: new[] { "JewelryID", "MaterialID" });

            migrationBuilder.AddForeignKey(
                name: "FK__JewelryMa__Jewel__3B75D760",
                table: "JewelryMaterial",
                column: "JewelryID",
                principalTable: "Jewelry",
                principalColumn: "JewelryID");

            migrationBuilder.AddForeignKey(
                name: "FK__JewelryMa__Mater__3C69FB99",
                table: "JewelryMaterial",
                column: "MaterialID",
                principalTable: "Material",
                principalColumn: "MaterialID");
        }
    }
}
