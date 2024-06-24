using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImageFromMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material");

            migrationBuilder.DropIndex(
                name: "IX_Material_ImageId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "CertificateImageId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "MaterialImageId",
                table: "Material");

            migrationBuilder.AddColumn<byte[]>(
                name: "CertificateImageData",
                table: "Material",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "MaterialImageData",
                table: "Material",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateImageData",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "MaterialImageData",
                table: "Material");

            migrationBuilder.AddColumn<Guid>(
                name: "CertificateImageId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MaterialImageId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Material_ImageId",
                table: "Material",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");
        }
    }
}
