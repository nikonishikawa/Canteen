using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CanteenClassLibrary.Entities;

public partial class CanteenContext : DbContext
{
    public CanteenContext()
    {
    }

    public CanteenContext(DbContextOptions<CanteenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAddress> TblAddresses { get; set; }

    public virtual DbSet<TblAddressGeneral> TblAddressGenerals { get; set; }

    public virtual DbSet<TblCategory> TblCategories { get; set; }

    public virtual DbSet<TblCourier> TblCouriers { get; set; }

    public virtual DbSet<TblCredential> TblCredentials { get; set; }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblItem> TblItems { get; set; }

    public virtual DbSet<TblMembership> TblMemberships { get; set; }

    public virtual DbSet<TblName> TblNames { get; set; }

    public virtual DbSet<TblOrderItem> TblOrderItems { get; set; }

    public virtual DbSet<TblOrderStatus> TblOrderStatuses { get; set; }

    public virtual DbSet<TblParcelInfo> TblParcelInfos { get; set; }

    public virtual DbSet<TblPosition> TblPositions { get; set; }

    public virtual DbSet<TblShippingStatus> TblShippingStatuses { get; set; }

    public virtual DbSet<TblTray> TblTrays { get; set; }

    public virtual DbSet<TblTrayItem> TblTrayItems { get; set; }

    public virtual DbSet<TblTrayStatus> TblTrayStatuses { get; set; }

    public virtual DbSet<TblVendor> TblVendors { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=nishikawa\\SQLEXPRESS;Database=Canteen;TrustServerCertificate=True;Trusted_Connection=true;");

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        { 
            optionsBuilder.UseSqlServer("NameDefaultCon");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAddress>(entity =>
        {
            entity.HasKey(e => e.AddressId);

            entity.ToTable("TblAddress");

            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.Barangay).HasMaxLength(50);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("Postal_Code");
            entity.Property(e => e.Region).HasMaxLength(50);
        });

        modelBuilder.Entity<TblAddressGeneral>(entity =>
        {
            entity.HasKey(e => e.GenAddressId);

            entity.ToTable("TblAddressGeneral");

            entity.Property(e => e.GenAddressId).HasColumnName("GenAddressID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.AddressId).HasColumnName("AddressID");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.CusId).HasColumnName("CusID");
            entity.Property(e => e.Email).HasMaxLength(50);

            entity.HasOne(d => d.AddressNavigation).WithMany(p => p.TblAddressGenerals)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblAddressGeneral_TblAddress");
        });

        modelBuilder.Entity<TblCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId);

            entity.ToTable("TblCategory");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<TblCourier>(entity =>
        {
            entity.HasKey(e => e.CourierId);

            entity.ToTable("TblCourier");

            entity.Property(e => e.CourierId).HasColumnName("CourierID");
            entity.Property(e => e.Courier).HasMaxLength(50);
        });

        modelBuilder.Entity<TblCredential>(entity =>
        {
            entity.HasKey(e => e.CredentialsId);

            entity.Property(e => e.CredentialsId).HasColumnName("CredentialsID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TblCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId);

            entity.ToTable("TblCustomer");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

            entity.HasOne(d => d.CusAddressNavigation).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.CusAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblCustomer_TblAddressGeneral");

            entity.HasOne(d => d.CusCredentialsNavigation).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.CusCredentials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblCustomer_TblCredentials");

            entity.HasOne(d => d.CusNameNavigation).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.CusName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblCustomer_TblName");

            entity.HasOne(d => d.MembershipNavigation).WithMany(p => p.TblCustomers)
                .HasForeignKey(d => d.Membership)
                .HasConstraintName("FK_TblCustomer_TblMembership");
        });

        modelBuilder.Entity<TblItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK_TblViand");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.FoodImage).HasMaxLength(50);
            entity.Property(e => e.IsHalal).HasColumnName("isHalal");
            entity.Property(e => e.Item).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.TblItems)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblViand_TblCategory");
        });

        modelBuilder.Entity<TblMembership>(entity =>
        {
            entity.HasKey(e => e.MemberShipId);

            entity.ToTable("TblMembership");

            entity.Property(e => e.MemberShipId).HasColumnName("MemberShipID");
            entity.Property(e => e.CusId).HasColumnName("CusID");
            entity.Property(e => e.Membership).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<TblName>(entity =>
        {
            entity.HasKey(e => e.NameId);

            entity.ToTable("TblName");

            entity.Property(e => e.NameId).HasColumnName("NameID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<TblOrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId);

            entity.ToTable("TblOrderItem");

            entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ItemNavigation).WithMany(p => p.TblOrderItems)
                .HasForeignKey(d => d.Item)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblOrderItem_TblViand");

            entity.HasOne(d => d.Order).WithMany(p => p.TblOrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblOrderItem_TblOrderStatus");
        });

        modelBuilder.Entity<TblOrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("TblOrderStatus");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CusId).HasColumnName("CusID");
            entity.Property(e => e.OrderStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.Cus).WithMany(p => p.TblOrderStatuses)
                .HasForeignKey(d => d.CusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblOrderStatus_TblCustomer");
        });

        modelBuilder.Entity<TblParcelInfo>(entity =>
        {
            entity.HasKey(e => e.TrackingId);

            entity.ToTable("TblParcelInfo");

            entity.Property(e => e.TrackingId).HasColumnName("TrackingID");
            entity.Property(e => e.Location).HasMaxLength(100);
            entity.Property(e => e.Notes).HasMaxLength(50);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShipStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.CourierNavigation).WithMany(p => p.TblParcelInfos)
                .HasForeignKey(d => d.Courier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblParcelInfo_TblCourier");

            entity.HasOne(d => d.Order).WithMany(p => p.TblParcelInfos)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblParcelInfo_TblOrderStatus");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.TblParcelInfos)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblParcelInfo_TblShippingStatus");
        });

        modelBuilder.Entity<TblPosition>(entity =>
        {
            entity.HasKey(e => e.PositionId);

            entity.ToTable("TblPosition");

            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.Position).HasMaxLength(50);
        });

        modelBuilder.Entity<TblShippingStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("TblShippingStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTray>(entity =>
        {
            entity.HasKey(e => e.TrayId);

            entity.ToTable("TblTray");

            entity.Property(e => e.TrayId).HasColumnName("TrayID");
            entity.Property(e => e.CusId).HasColumnName("CusID");

            entity.HasOne(d => d.Cus).WithMany(p => p.TblTrays)
                .HasForeignKey(d => d.CusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTray_TblCustomer");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.TblTrays)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTray_TblTrayStatus");
        });

        modelBuilder.Entity<TblTrayItem>(entity =>
        {
            entity.HasKey(e => e.TrayItemId);

            entity.Property(e => e.TrayItemId).HasColumnName("TrayItemID");
            entity.Property(e => e.AddStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TrayId).HasColumnName("TrayID");

            entity.HasOne(d => d.ItemNavigation).WithMany(p => p.TblTrayItems)
                .HasForeignKey(d => d.Item)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTrayItems_TblViand");

            entity.HasOne(d => d.Tray).WithMany(p => p.TblTrayItems)
                .HasForeignKey(d => d.TrayId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblTrayItems_TblTray");
        });

        modelBuilder.Entity<TblTrayStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("TblTrayStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<TblVendor>(entity =>
        {
            entity.HasKey(e => e.VendorId);

            entity.ToTable("TblVendor");

            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.PositionNavigation).WithMany(p => p.TblVendors)
                .HasForeignKey(d => d.Position)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblVendor_TblPosition");

            entity.HasOne(d => d.VendAddressNavigation).WithMany(p => p.TblVendors)
                .HasForeignKey(d => d.VendAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblVendor_TblAddressGeneral");

            entity.HasOne(d => d.VendCredentialsNavigation).WithMany(p => p.TblVendors)
                .HasForeignKey(d => d.VendCredentials)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblVendor_TblCredentials");

            entity.HasOne(d => d.VendNameNavigation).WithMany(p => p.TblVendors)
                .HasForeignKey(d => d.VendName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TblVendor_TblName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
