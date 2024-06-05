using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ConvertToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportTime",
                table: "JewelryMaterial");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "JewelryMaterial");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ImportTime",
                table: "JewelryMaterial",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "JewelryMaterial",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
