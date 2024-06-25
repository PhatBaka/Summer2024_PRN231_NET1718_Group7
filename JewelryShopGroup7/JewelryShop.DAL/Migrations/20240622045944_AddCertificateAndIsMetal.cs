using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCertificateAndIsMetal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CertificateId",
                table: "Material",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsMetal",
                table: "Material",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificateId",
                table: "Material");

            migrationBuilder.DropColumn(
                name: "IsMetal",
                table: "Material");
        }
    }
}
