using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AmountSpent = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B84ABA9FFB", x => x.CustomerID);
                });

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

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    MaterialID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Material__C506131735D61340", x => x.MaterialID);
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

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Role = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__8AFACE3A89C40932", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "StoreDiscount",
                columns: table => new
                {
                    StoreDiscountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    DiscountCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    RemainingUsage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__StoreDis__95AED7FC4C396FBE", x => x.StoreDiscountID);
                });

            migrationBuilder.CreateTable(
                name: "Tier",
                columns: table => new
                {
                    TierID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TierName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MinAmountSpent = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tier__362F55FD75EB3162", x => x.TierID);
                });

            migrationBuilder.CreateTable(
                name: "Jewelry",
                columns: table => new
                {
                    JewelryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ManufacturingFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    JewelryType = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GuaranteeDuration = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Jewelry__807031F553A60101", x => x.JewelryID);
                    table.ForeignKey(
                        name: "FK__Jewelry__Jewelry__38996AB5",
                        column: x => x.JewelryType,
                        principalTable: "JewelryType",
                        principalColumn: "TypeID");
                });

            migrationBuilder.CreateTable(
                name: "MaterialPrice",
                columns: table => new
                {
                    MaterialPriceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MaterialID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
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
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__349DA5864C3336AA", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK__Account__RoleID__286302EC",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "JewelryMaterial",
                columns: table => new
                {
                    JewelryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaterialID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__JewelryM__EC2050C484ACE139", x => new { x.JewelryID, x.MaterialID });
                    table.ForeignKey(
                        name: "FK__JewelryMa__Jewel__3B75D760",
                        column: x => x.JewelryID,
                        principalTable: "Jewelry",
                        principalColumn: "JewelryID");
                    table.ForeignKey(
                        name: "FK__JewelryMa__Mater__3C69FB99",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "MaterialID");
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    OfferID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OfferPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Constraints = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApprovedByID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Offer__8EBCF0B1113F2291", x => x.OfferID);
                    table.ForeignKey(
                        name: "FK__Offer__ApprovedB__46E78A0C",
                        column: x => x.ApprovedByID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK__Offer__CreatedBy__45F365D3",
                        column: x => x.CreatedByID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDiscount",
                columns: table => new
                {
                    OrderDiscountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TierID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StoreDiscountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OfferID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDis__5EF1875E2279D142", x => x.OrderDiscountID);
                    table.ForeignKey(
                        name: "FK__OrderDisc__Offer__4F7CD00D",
                        column: x => x.OfferID,
                        principalTable: "Offer",
                        principalColumn: "OfferID");
                    table.ForeignKey(
                        name: "FK__OrderDisc__Store__4E88ABD4",
                        column: x => x.StoreDiscountID,
                        principalTable: "StoreDiscount",
                        principalColumn: "StoreDiscountID");
                    table.ForeignKey(
                        name: "FK__OrderDisc__TierI__4D94879B",
                        column: x => x.TierID,
                        principalTable: "Tier",
                        principalColumn: "TierID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OrderTypeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderDiscountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CustomerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__C3905BAF5AB6F0BA", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Order__AccountID__5535A963",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK__Order__CustomerI__5629CD9C",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Order__OrderDisc__5441852A",
                        column: x => x.OrderDiscountID,
                        principalTable: "OrderDiscount",
                        principalColumn: "OrderDiscountID");
                    table.ForeignKey(
                        name: "FK__Order__OrderType__534D60F1",
                        column: x => x.OrderTypeID,
                        principalTable: "OrderType",
                        principalColumn: "OrderTypeID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JewelryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__D3B9D30CEB633F73", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK__OrderDeta__Jewel__5AEE82B9",
                        column: x => x.JewelryID,
                        principalTable: "Jewelry",
                        principalColumn: "JewelryID");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__59FA5E80",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "Guarantee",
                columns: table => new
                {
                    GuaranteeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrderDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateReceive = table.Column<DateTime>(type: "date", nullable: true),
                    DateComplete = table.Column<DateTime>(type: "date", nullable: true),
                    DateBack = table.Column<DateTime>(type: "date", nullable: true),
                    Confirm = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Guarante__7EC2C70046FD3E75", x => x.GuaranteeID);
                    table.ForeignKey(
                        name: "FK__Guarantee__Accou__5EBF139D",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK__Guarantee__Order__5FB337D6",
                        column: x => x.OrderDetailID,
                        principalTable: "OrderDetail",
                        principalColumn: "OrderDetailID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleID",
                table: "Account",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Guarantee_AccountID",
                table: "Guarantee",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Guarantee_OrderDetailID",
                table: "Guarantee",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_JewelryType",
                table: "Jewelry",
                column: "JewelryType");

            migrationBuilder.CreateIndex(
                name: "IX_JewelryMaterial_MaterialID",
                table: "JewelryMaterial",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialPrice_MaterialID",
                table: "MaterialPrice",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_ApprovedByID",
                table: "Offer",
                column: "ApprovedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_CreatedByID",
                table: "Offer",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountID",
                table: "Order",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderDiscountID",
                table: "Order",
                column: "OrderDiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderTypeID",
                table: "Order",
                column: "OrderTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_JewelryID",
                table: "OrderDetail",
                column: "JewelryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscount_OfferID",
                table: "OrderDiscount",
                column: "OfferID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscount_StoreDiscountID",
                table: "OrderDiscount",
                column: "StoreDiscountID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDiscount_TierID",
                table: "OrderDiscount",
                column: "TierID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guarantee");

            migrationBuilder.DropTable(
                name: "JewelryMaterial");

            migrationBuilder.DropTable(
                name: "MaterialPrice");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Jewelry");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "JewelryType");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "OrderDiscount");

            migrationBuilder.DropTable(
                name: "OrderType");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "StoreDiscount");

            migrationBuilder.DropTable(
                name: "Tier");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
