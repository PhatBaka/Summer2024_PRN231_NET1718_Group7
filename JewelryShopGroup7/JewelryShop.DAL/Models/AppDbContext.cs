using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JewelryShop.DAL.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Guarantee> Guarantees { get; set; }

    public virtual DbSet<Jewelry> Jewelries { get; set; }

    public virtual DbSet<JewelryMaterial> JewelryMaterials { get; set; }

    public virtual DbSet<JewelryType> JewelryTypes { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<MaterialPrice> MaterialPrices { get; set; }

    public virtual DbSet<Offer> Offers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderDiscount> OrderDiscounts { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<StoreDiscount> StoreDiscounts { get; set; }

    public virtual DbSet<Tier> Tiers { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer("Server=(local);uid=sa;pwd=sa;database=JewelryShop;TrustServerCertificate=True");
        optionsBuilder.UseLazyLoadingProxies();
        var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("JewelryShop"), b => b.MigrationsAssembly("JewelryShop.DAL"));
    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5864C3336AA");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("AccountID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__RoleID__286302EC");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B84ABA9FFB");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("CustomerID");
            entity.Property(e => e.AmountSpent).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Guarantee>(entity =>
        {
            entity.HasKey(e => e.GuaranteeId).HasName("PK__Guarante__7EC2C70046FD3E75");

            entity.ToTable("Guarantee");

            entity.Property(e => e.GuaranteeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GuaranteeID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.Confirm).HasMaxLength(50);
            entity.Property(e => e.DateBack).HasColumnType("date");
            entity.Property(e => e.DateComplete).HasColumnType("date");
            entity.Property(e => e.DateReceive).HasColumnType("date");
            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");

            entity.HasOne(d => d.Account).WithMany(p => p.Guarantees)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Guarantee__Accou__5EBF139D");

            entity.HasOne(d => d.OrderDetail).WithMany(p => p.Guarantees)
                .HasForeignKey(d => d.OrderDetailId)
                .HasConstraintName("FK__Guarantee__Order__5FB337D6");
        });

        modelBuilder.Entity<Jewelry>(entity =>
        {
            entity.HasKey(e => e.JewelryId).HasName("PK__Jewelry__807031F553A60101");

            entity.ToTable("Jewelry");

            entity.Property(e => e.JewelryId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("JewelryID");
            entity.Property(e => e.Barcode).HasMaxLength(255);
            entity.Property(e => e.ManufacturingFees).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.JewelryTypeNavigation).WithMany(p => p.Jewelries)
                .HasForeignKey(d => d.JewelryType)
                .HasConstraintName("FK__Jewelry__Jewelry__38996AB5");
        });

        modelBuilder.Entity<JewelryMaterial>(entity =>
        {
            entity.HasKey(e => new { e.JewelryId, e.MaterialId }).HasName("PK__JewelryM__EC2050C484ACE139");

            entity.ToTable("JewelryMaterial");

            entity.Property(e => e.JewelryId).HasColumnName("JewelryID");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Jewelry).WithMany(p => p.JewelryMaterials)
                .HasForeignKey(d => d.JewelryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JewelryMa__Jewel__3B75D760");

            entity.HasOne(d => d.Material).WithMany(p => p.JewelryMaterials)
                .HasForeignKey(d => d.MaterialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__JewelryMa__Mater__3C69FB99");
        });

        modelBuilder.Entity<JewelryType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__JewelryT__516F0395CCBB916E");

            entity.ToTable("JewelryType");

            entity.Property(e => e.TypeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TypeID");
            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.MaterialId).HasName("PK__Material__C506131735D61340");

            entity.ToTable("Material");

            entity.Property(e => e.MaterialId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("MaterialID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<MaterialPrice>(entity =>
        {
            entity.HasKey(e => e.MaterialPriceId).HasName("PK__Material__59B706AE2621B949");

            entity.ToTable("MaterialPrice");

            entity.Property(e => e.MaterialPriceId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("MaterialPriceID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.MaterialId).HasColumnName("MaterialID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Material).WithMany(p => p.MaterialPrices)
                .HasForeignKey(d => d.MaterialId)
                .HasConstraintName("FK__MaterialP__Mater__31EC6D26");
        });

        modelBuilder.Entity<Offer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PK__Offer__8EBCF0B1113F2291");

            entity.ToTable("Offer");

            entity.Property(e => e.OfferId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OfferID");
            entity.Property(e => e.ApprovedById).HasColumnName("ApprovedByID");
            entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");
            entity.Property(e => e.OfferPercent).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.ApprovedBy).WithMany(p => p.OfferApprovedBies)
                .HasForeignKey(d => d.ApprovedById)
                .HasConstraintName("FK__Offer__ApprovedB__46E78A0C");

            entity.HasOne(d => d.CreatedBy).WithMany(p => p.OfferCreatedBies)
                .HasForeignKey(d => d.CreatedById)
                .HasConstraintName("FK__Offer__CreatedBy__45F365D3");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BAF5AB6F0BA");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OrderID");
            entity.Property(e => e.AccountId).HasColumnName("AccountID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DiscountPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FinalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderDiscountId).HasColumnName("OrderDiscountID");
            //entity.Property(e => e.OrderTypeId).HasColumnName("OrderTypeID");
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Order__AccountID__5535A963");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Order__CustomerI__5629CD9C");

            entity.HasOne(d => d.OrderDiscount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderDiscountId)
                .HasConstraintName("FK__Order__OrderDisc__5441852A");

            //entity.HasOne(d => d.OrderType).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.OrderTypeId)
            //    .HasConstraintName("FK__Order__OrderType__534D60F1");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30CEB633F73");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderDetailId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.JewelryId).HasColumnName("JewelryID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            //entity.Property(e => e.SubTotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Jewelry).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.JewelryId)
                .HasConstraintName("FK__OrderDeta__Jewel__5AEE82B9");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__59FA5E80");
        });

        modelBuilder.Entity<OrderDiscount>(entity =>
        {
            entity.HasKey(e => e.OrderDiscountId).HasName("PK__OrderDis__5EF1875E2279D142");

            entity.ToTable("OrderDiscount");

            entity.Property(e => e.OrderDiscountId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OrderDiscountID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.OfferId).HasColumnName("OfferID");
            entity.Property(e => e.StoreDiscountId).HasColumnName("StoreDiscountID");
            entity.Property(e => e.TierId).HasColumnName("TierID");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Offer).WithMany(p => p.OrderDiscounts)
                .HasForeignKey(d => d.OfferId)
                .HasConstraintName("FK__OrderDisc__Offer__4F7CD00D");

            entity.HasOne(d => d.StoreDiscount).WithMany(p => p.OrderDiscounts)
                .HasForeignKey(d => d.StoreDiscountId)
                .HasConstraintName("FK__OrderDisc__Store__4E88ABD4");

            entity.HasOne(d => d.Tier).WithMany(p => p.OrderDiscounts)
                .HasForeignKey(d => d.TierId)
                .HasConstraintName("FK__OrderDisc__TierI__4D94879B");
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.HasKey(e => e.OrderTypeId).HasName("PK__OrderTyp__23AC264CD2AC420D");

            entity.ToTable("OrderType");

            entity.Property(e => e.OrderTypeId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("OrderTypeID");
            entity.Property(e => e.TypeName).HasMaxLength(255);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A89C40932");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("RoleID");
            entity.Property(e => e.Role1)
                .HasMaxLength(255)
                .HasColumnName("Role");
        });

        modelBuilder.Entity<StoreDiscount>(entity =>
        {
            entity.HasKey(e => e.StoreDiscountId).HasName("PK__StoreDis__95AED7FC4C396FBE");

            entity.ToTable("StoreDiscount");

            entity.Property(e => e.StoreDiscountId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("StoreDiscountID");
            entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DiscountCode).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Tier>(entity =>
        {
            entity.HasKey(e => e.TierId).HasName("PK__Tier__362F55FD75EB3162");

            entity.ToTable("Tier");

            entity.Property(e => e.TierId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TierID");
            entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.MinAmountSpent).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TierName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
