using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jewelry_Image_ImageId",
                table: "Jewelry");

            migrationBuilder.DropIndex(
                name: "IX_Jewelry_ImageId",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "JewelryMaterial");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "SellPrice",
                table: "Jewelry");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialStatus",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Jewelry",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "JewelryCategory",
                table: "Jewelry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "MaterialPrice",
                table: "Jewelry",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JewelryCategory",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "MaterialPrice",
                table: "Jewelry");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialStatus",
                table: "Material",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "JewelryMaterial",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Jewelry",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Jewelry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "SellPrice",
                table: "Jewelry",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
        }
    }
}
