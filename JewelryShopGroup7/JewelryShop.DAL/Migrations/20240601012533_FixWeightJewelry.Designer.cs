﻿// <auto-generated />
using System;
using JewelryShop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JewelryShop.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240601012533_FixWeightJewelry")]
    partial class FixWeightJewelry
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.19")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JewelryShop.DAL.Models.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Password")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleID");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AccountId")
                        .HasName("PK__Account__349DA5864C3336AA");

                    b.HasIndex("RoleId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Customer", b =>
                {
                    b.Property<Guid>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal>("AmountSpent")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__A4AE64B84ABA9FFB");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Guarantee", b =>
                {
                    b.Property<Guid>("GuaranteeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("GuaranteeID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<string>("Confirm")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateBack")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateComplete")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateReceive")
                        .HasColumnType("date");

                    b.Property<Guid?>("OrderDetailId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderDetailID");

                    b.HasKey("GuaranteeId")
                        .HasName("PK__Guarante__7EC2C70046FD3E75");

                    b.HasIndex("AccountId");

                    b.HasIndex("OrderDetailId");

                    b.ToTable("Guarantee", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Image", b =>
                {
                    b.Property<Guid>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ImageId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Jewelry", b =>
                {
                    b.Property<Guid>("JewelryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("JewelryID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Barcode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("GuaranteeDuration")
                        .HasColumnType("int");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("JewelryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("JewelryType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("ManufacturingFees")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("MarkupPercentage")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SellPrice")
                        .HasColumnType("float");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("TotalWeight")
                        .HasColumnType("float");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("JewelryId")
                        .HasName("PK__Jewelry__807031F553A60101");

                    b.HasIndex("ImageId");

                    b.HasIndex("JewelryType");

                    b.ToTable("Jewelry", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.JewelryMaterial", b =>
                {
                    b.Property<Guid>("JewelryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("JewelryID");

                    b.Property<Guid>("MaterialId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MaterialID");

                    b.Property<DateTime>("ImportTime")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<decimal?>("Weight")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("JewelryId", "MaterialId")
                        .HasName("PK__JewelryM__EC2050C484ACE139");

                    b.HasIndex("MaterialId");

                    b.ToTable("JewelryMaterial", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.JewelryType", b =>
                {
                    b.Property<Guid>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TypeID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("TypeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TypeId")
                        .HasName("PK__JewelryT__516F0395CCBB916E");

                    b.ToTable("JewelryType", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Material", b =>
                {
                    b.Property<Guid>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MaterialID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialId")
                        .HasName("PK__Material__C506131735D61340");

                    b.HasIndex("ImageId");

                    b.ToTable("Material", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.MaterialPrice", b =>
                {
                    b.Property<Guid>("MaterialPriceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MaterialPriceID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<Guid?>("MaterialId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("MaterialID");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("UnitType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaterialPriceId")
                        .HasName("PK__Material__59B706AE2621B949");

                    b.HasIndex("MaterialId");

                    b.ToTable("MaterialPrice", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Offer", b =>
                {
                    b.Property<Guid>("OfferId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OfferID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("ApprovedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ApprovedByID");

                    b.Property<string>("Constraints")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CreatedByID");

                    b.Property<decimal?>("OfferPercent")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("OfferId")
                        .HasName("PK__Offer__8EBCF0B1113F2291");

                    b.HasIndex("ApprovedById");

                    b.HasIndex("CreatedById");

                    b.ToTable("Offer", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("AccountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("AccountID");

                    b.Property<Guid?>("CustomerId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("CustomerID");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal?>("FinalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("OrderDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("OrderDiscountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderDiscountID");

                    b.Property<Guid?>("OrderTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderTypeID");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("OrderId")
                        .HasName("PK__Order__C3905BAF5AB6F0BA");

                    b.HasIndex("AccountId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderDiscountId");

                    b.HasIndex("OrderTypeId");

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderDetail", b =>
                {
                    b.Property<Guid>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderDetailID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("JewelryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("JewelryID");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderID");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("SubTotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("OrderDetailId")
                        .HasName("PK__OrderDet__D3B9D30CEB633F73");

                    b.HasIndex("JewelryId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetail", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderDiscount", b =>
                {
                    b.Property<Guid>("OrderDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderDiscountID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("OfferId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OfferID");

                    b.Property<Guid?>("StoreDiscountId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StoreDiscountID");

                    b.Property<Guid?>("TierId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TierID");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("OrderDiscountId")
                        .HasName("PK__OrderDis__5EF1875E2279D142");

                    b.HasIndex("OfferId");

                    b.HasIndex("StoreDiscountId");

                    b.HasIndex("TierId");

                    b.ToTable("OrderDiscount", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderType", b =>
                {
                    b.Property<Guid>("OrderTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OrderTypeID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("TypeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("OrderTypeId")
                        .HasName("PK__OrderTyp__23AC264CD2AC420D");

                    b.ToTable("OrderType", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Role", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("RoleID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Role1")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Role");

                    b.HasKey("RoleId")
                        .HasName("PK__Role__8AFACE3A89C40932");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.StoreDiscount", b =>
                {
                    b.Property<Guid>("StoreDiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("StoreDiscountID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal?>("DiscountAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("DiscountCode")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("date");

                    b.Property<int?>("RemainingUsage")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("StoreDiscountId")
                        .HasName("PK__StoreDis__95AED7FC4C396FBE");

                    b.ToTable("StoreDiscount", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Tier", b =>
                {
                    b.Property<Guid>("TierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("TierID")
                        .HasDefaultValueSql("(newid())");

                    b.Property<decimal?>("DiscountPercentage")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("MinAmountSpent")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<string>("TierName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TierId")
                        .HasName("PK__Tier__362F55FD75EB3162");

                    b.ToTable("Tier", (string)null);
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Account", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Account__RoleID__286302EC");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Guarantee", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Account", "Account")
                        .WithMany("Guarantees")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Guarantee__Accou__5EBF139D");

                    b.HasOne("JewelryShop.DAL.Models.OrderDetail", "OrderDetail")
                        .WithMany("Guarantees")
                        .HasForeignKey("OrderDetailId")
                        .HasConstraintName("FK__Guarantee__Order__5FB337D6");

                    b.Navigation("Account");

                    b.Navigation("OrderDetail");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Jewelry", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Image", "Image")
                        .WithMany("Jewelries")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JewelryShop.DAL.Models.JewelryType", "JewelryTypeNavigation")
                        .WithMany("Jewelries")
                        .HasForeignKey("JewelryType")
                        .HasConstraintName("FK__Jewelry__Jewelry__38996AB5");

                    b.Navigation("Image");

                    b.Navigation("JewelryTypeNavigation");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.JewelryMaterial", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Jewelry", "Jewelry")
                        .WithMany("JewelryMaterials")
                        .HasForeignKey("JewelryId")
                        .IsRequired()
                        .HasConstraintName("FK__JewelryMa__Jewel__3B75D760");

                    b.HasOne("JewelryShop.DAL.Models.Material", "Material")
                        .WithMany("JewelryMaterials")
                        .HasForeignKey("MaterialId")
                        .IsRequired()
                        .HasConstraintName("FK__JewelryMa__Mater__3C69FB99");

                    b.Navigation("Jewelry");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Material", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Image", "Image")
                        .WithMany("Materials")
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.MaterialPrice", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Material", "Material")
                        .WithMany("MaterialPrices")
                        .HasForeignKey("MaterialId")
                        .HasConstraintName("FK__MaterialP__Mater__31EC6D26");

                    b.Navigation("Material");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Offer", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Account", "ApprovedBy")
                        .WithMany("OfferApprovedBies")
                        .HasForeignKey("ApprovedById")
                        .HasConstraintName("FK__Offer__ApprovedB__46E78A0C");

                    b.HasOne("JewelryShop.DAL.Models.Account", "CreatedBy")
                        .WithMany("OfferCreatedBies")
                        .HasForeignKey("CreatedById")
                        .HasConstraintName("FK__Offer__CreatedBy__45F365D3");

                    b.Navigation("ApprovedBy");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Order", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Account", "Account")
                        .WithMany("Orders")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Order__AccountID__5535A963");

                    b.HasOne("JewelryShop.DAL.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK__Order__CustomerI__5629CD9C");

                    b.HasOne("JewelryShop.DAL.Models.OrderDiscount", "OrderDiscount")
                        .WithMany("Orders")
                        .HasForeignKey("OrderDiscountId")
                        .HasConstraintName("FK__Order__OrderDisc__5441852A");

                    b.HasOne("JewelryShop.DAL.Models.OrderType", "OrderType")
                        .WithMany("Orders")
                        .HasForeignKey("OrderTypeId")
                        .HasConstraintName("FK__Order__OrderType__534D60F1");

                    b.Navigation("Account");

                    b.Navigation("Customer");

                    b.Navigation("OrderDiscount");

                    b.Navigation("OrderType");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderDetail", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Jewelry", "Jewelry")
                        .WithMany("OrderDetails")
                        .HasForeignKey("JewelryId")
                        .HasConstraintName("FK__OrderDeta__Jewel__5AEE82B9");

                    b.HasOne("JewelryShop.DAL.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__OrderDeta__Order__59FA5E80");

                    b.Navigation("Jewelry");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderDiscount", b =>
                {
                    b.HasOne("JewelryShop.DAL.Models.Offer", "Offer")
                        .WithMany("OrderDiscounts")
                        .HasForeignKey("OfferId")
                        .HasConstraintName("FK__OrderDisc__Offer__4F7CD00D");

                    b.HasOne("JewelryShop.DAL.Models.StoreDiscount", "StoreDiscount")
                        .WithMany("OrderDiscounts")
                        .HasForeignKey("StoreDiscountId")
                        .HasConstraintName("FK__OrderDisc__Store__4E88ABD4");

                    b.HasOne("JewelryShop.DAL.Models.Tier", "Tier")
                        .WithMany("OrderDiscounts")
                        .HasForeignKey("TierId")
                        .HasConstraintName("FK__OrderDisc__TierI__4D94879B");

                    b.Navigation("Offer");

                    b.Navigation("StoreDiscount");

                    b.Navigation("Tier");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Account", b =>
                {
                    b.Navigation("Guarantees");

                    b.Navigation("OfferApprovedBies");

                    b.Navigation("OfferCreatedBies");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Image", b =>
                {
                    b.Navigation("Jewelries");

                    b.Navigation("Materials");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Jewelry", b =>
                {
                    b.Navigation("JewelryMaterials");

                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.JewelryType", b =>
                {
                    b.Navigation("Jewelries");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Material", b =>
                {
                    b.Navigation("JewelryMaterials");

                    b.Navigation("MaterialPrices");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Offer", b =>
                {
                    b.Navigation("OrderDiscounts");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderDetail", b =>
                {
                    b.Navigation("Guarantees");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderDiscount", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.OrderType", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.StoreDiscount", b =>
                {
                    b.Navigation("OrderDiscounts");
                });

            modelBuilder.Entity("JewelryShop.DAL.Models.Tier", b =>
                {
                    b.Navigation("OrderDiscounts");
                });
#pragma warning restore 612, 618
        }
    }
}
