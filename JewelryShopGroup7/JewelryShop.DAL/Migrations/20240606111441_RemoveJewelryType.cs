using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveJewelryType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Jewelry__Jewelry__38996AB5",
                table: "Jewelry");

            migrationBuilder.DropTable(
                name: "JewelryType");

            migrationBuilder.DropIndex(
                name: "IX_Jewelry_JewelryType",
                table: "Jewelry");

            migrationBuilder.AlterColumn<string>(
                name: "JewelryType",
                table: "Jewelry",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "JewelryType",
                table: "Jewelry",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "JewelryType",
                columns: table => new
                {
                    TypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JewelryT__516F0395CCBB916E", x => x.TypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_JewelryType",
                table: "Jewelry",
                column: "JewelryType");

            migrationBuilder.AddForeignKey(
                name: "FK__Jewelry__Jewelry__38996AB5",
                table: "Jewelry",
                column: "JewelryType",
                principalTable: "JewelryType",
                principalColumn: "TypeID");
        }
    }
}
