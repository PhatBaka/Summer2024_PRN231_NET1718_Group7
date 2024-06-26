using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalPriceAndDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Material",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Jewelry",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGemPrice",
                table: "Jewelry",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMetalPrice",
                table: "Jewelry",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Jewelry",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "TotalGemPrice",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "TotalMetalPrice",
                table: "Jewelry");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Jewelry");
        }
    }
}
