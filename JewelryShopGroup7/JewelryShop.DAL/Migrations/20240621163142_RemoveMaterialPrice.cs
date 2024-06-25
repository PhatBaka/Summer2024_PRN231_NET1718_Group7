using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMaterialPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order");

            migrationBuilder.DropTable(
                name: "MaterialPrice");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderTypeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Material");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "OrderDiscount",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "OrderDiscount");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderTypeId",
                table: "Order",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Material",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MaterialPrice",
                columns: table => new
                {
                    MaterialPriceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaterialID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Material__59B706AE2621B949", x => x.MaterialPriceID);
                    table.ForeignKey(
                        name: "FK__MaterialP__Mater__31EC6D26",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "MaterialID");
                });

            migrationBuilder.CreateTable(
                name: "OrderType",
                columns: table => new
                {
                    OrderTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TypeName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderTyp__23AC264CD2AC420D", x => x.OrderTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order",
                column: "OrderTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPrice_MaterialID",
                table: "MaterialPrice",
                column: "MaterialID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order",
                column: "OrderTypeId",
                principalTable: "OrderType",
                principalColumn: "OrderTypeID");
        }
    }
}
