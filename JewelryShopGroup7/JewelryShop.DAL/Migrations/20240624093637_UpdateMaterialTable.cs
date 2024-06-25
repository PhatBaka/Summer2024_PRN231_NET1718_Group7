using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMaterialTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material");

            //migrationBuilder.DropForeignKey(
            //    name: "FK__MaterialP__Mater__31EC6D26",
            //    table: "MaterialPrice");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "MarkupPercentage",
                table: "Jewelry");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Material",
                newName: "Weight");

            //migrationBuilder.RenameColumn(
            //    name: "Date",
            //    table: "Material",
            //    newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "Material",
                newName: "MaterialImageId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Material",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CertificateImageId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Clarity",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "InitialPrice",
                table: "Material",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Purity",
                table: "Material",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Sharp",
                table: "Material",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "Material",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "JewelryName",
                table: "Jewelry",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "JewelryID",
                table: "Jewelry",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Image",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MaterialPrice_Material_MaterialID",
            //    table: "MaterialPrice",
            //    column: "MaterialID",
            //    principalTable: "Material",
            //    principalColumn: "MaterialID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_MaterialPrice_Material_MaterialID",
            //    table: "MaterialPrice");

            migrationBuilder.DropColumn(
                name: "CertificateImageId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Clarity",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "InitialPrice",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Purity",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "Sharp",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Material",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "MaterialImageId",
                table: "Material",
                newName: "CertificateId");

            //migrationBuilder.RenameColumn(
            //    name: "CreatedDate",
            //    table: "Material",
            //    newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Material",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<Guid>(
                name: "ImageId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitType",
                table: "Material",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "JewelryName",
                table: "Jewelry",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "JewelryID",
                table: "Jewelry",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "Jewelry",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MarkupPercentage",
                table: "Jewelry",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Image_ImageId",
                table: "Material",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK__MaterialP__Mater__31EC6D26",
            //    table: "MaterialPrice",
            //    column: "MaterialID",
            //    principalTable: "Material",
            //    principalColumn: "MaterialID");
        }
    }
}
