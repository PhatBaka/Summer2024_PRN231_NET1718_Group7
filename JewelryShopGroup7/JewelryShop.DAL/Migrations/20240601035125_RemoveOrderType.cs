using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Order__OrderType__534D60F1",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderTypeID",
                table: "Order",
                newName: "OrderTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderTypeID",
                table: "Order",
                newName: "IX_Order_OrderTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order",
                column: "OrderTypeId",
                principalTable: "OrderType",
                principalColumn: "OrderTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderType_OrderTypeId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "OrderTypeId",
                table: "Order",
                newName: "OrderTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderTypeId",
                table: "Order",
                newName: "IX_Order_OrderTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK__Order__OrderType__534D60F1",
                table: "Order",
                column: "OrderTypeID",
                principalTable: "OrderType",
                principalColumn: "OrderTypeID");
        }
    }
}
