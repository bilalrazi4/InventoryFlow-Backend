using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryFlow.Domain.DbModels;

public partial class HfinventoryFlowContext : DbContext
{
    public HfinventoryFlowContext()
    {
    }

    public HfinventoryFlowContext(DbContextOptions<HfinventoryFlowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<GeoLevel> GeoLevels { get; set; }

    public virtual DbSet<HealthFacilitiesNew> HealthFacilitiesNews { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestMaster> RequestMasters { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockOut> StockOuts { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=HFInventoryFlow;Integrated Security=true;Encrypt=false;TrustServerCertificate=true;"
);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Cnic).HasColumnName("CNIC");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.ToTable("Attachment");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<GeoLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.GeoLevels");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .HasColumnName("CODE");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .HasColumnName("CREATED_BY");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.EnableFlag)
                .HasMaxLength(10)
                .HasColumnName("ENABLE_FLAG");
            entity.Property(e => e.Fkcode)
                .HasMaxLength(50)
                .HasColumnName("FKCODE");
            entity.Property(e => e.Hrpkcode)
                .HasMaxLength(50)
                .HasColumnName("HRPKCODE");
            entity.Property(e => e.IsPhcipdistrict).HasColumnName("IsPHCIPDistrict");
            entity.Property(e => e.IsPhfmc).HasColumnName("IsPHFMC");
            entity.Property(e => e.LastMrTokenUpdate).HasColumnType("datetime");
            entity.Property(e => e.LastMrnumber)
                .HasMaxLength(100)
                .HasColumnName("LastMRNumber");
            entity.Property(e => e.LastSyncDateTime).HasColumnType("datetime");
            entity.Property(e => e.Lvl)
                .HasMaxLength(100)
                .HasColumnName("LVL");
            entity.Property(e => e.Name)
                .HasMaxLength(500)
                .HasColumnName("NAME");
            entity.Property(e => e.ParentId).HasColumnName("Parent_Id");
            entity.Property(e => e.Pkcode)
                .HasMaxLength(50)
                .HasColumnName("PKCODE");
            entity.Property(e => e.UpdationDate)
                .HasColumnType("datetime")
                .HasColumnName("UPDATION_DATE");
            entity.Property(e => e.UpdtedBy)
                .HasMaxLength(100)
                .HasColumnName("UPDTED_BY");
        });

        modelBuilder.Entity<HealthFacilitiesNew>(entity =>
        {
            entity.ToTable("health_facilities_new");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AreaType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("area_type");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .HasColumnName("class");
            entity.Property(e => e.DateCreated)
                .HasColumnType("datetime")
                .HasColumnName("date_created");
            entity.Property(e => e.DateUpdated)
                .HasColumnType("datetime")
                .HasColumnName("date_updated");
            entity.Property(e => e.Dhisuid)
                .HasMaxLength(50)
                .HasColumnName("DHISUID");
            entity.Property(e => e.DistrictId).HasColumnName("district_id");
            entity.Property(e => e.Dsr).HasColumnName("dsr");
            entity.Property(e => e.Emr).HasColumnName("emr");
            entity.Property(e => e.FacilityCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("facility_code");
            entity.Property(e => e.FacilityId)
                .HasMaxLength(50)
                .HasColumnName("facility_id");
            entity.Property(e => e.FacilityName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("facility_name");
            entity.Property(e => e.FacilityStatus).HasColumnName("facility_status");
            entity.Property(e => e.FacilityType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("facility_type");
            entity.Property(e => e.FunctionStatus)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HrDistrictCode)
                .HasMaxLength(100)
                .HasColumnName("HR_District_Code");
            entity.Property(e => e.HrDistrictName)
                .HasMaxLength(100)
                .HasColumnName("HR_DistrictName");
            entity.Property(e => e.HrDivisionCode)
                .HasMaxLength(100)
                .HasColumnName("HR_DivisionCode");
            entity.Property(e => e.HrDivisionName)
                .HasMaxLength(100)
                .HasColumnName("HR_DivisionName");
            entity.Property(e => e.HrHftype)
                .HasMaxLength(250)
                .HasColumnName("HR_HFType");
            entity.Property(e => e.HrTehsilCode)
                .HasMaxLength(100)
                .HasColumnName("HR_Tehsil_Code");
            entity.Property(e => e.HrTehsilName)
                .HasMaxLength(100)
                .HasColumnName("HR_TehsilName");
            entity.Property(e => e.HrmisCode)
                .HasMaxLength(100)
                .HasColumnName("HRMIS_CODE");
            entity.Property(e => e.HrmisHfTypeCode)
                .HasMaxLength(50)
                .HasColumnName("Hrmis_hfTypeCode");
            entity.Property(e => e.HrmisHfTypeName)
                .HasMaxLength(100)
                .HasColumnName("Hrmis_hfTypeName");
            entity.Property(e => e.HrmisId).HasColumnName("HRMIS_ID");
            entity.Property(e => e.IrmnchFacility).HasColumnName("irmnch_facility");
            entity.Property(e => e.IsDeviceCheck).HasDefaultValue(false);
            entity.Property(e => e.MeaRegion).HasColumnName("mea_region");
            entity.Property(e => e.OldHfid).HasColumnName("OldHFId");
            entity.Property(e => e.Otp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("otp");
            entity.Property(e => e.Phase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phase");
            entity.Property(e => e.PhcipFacility).HasColumnName("PHCIP_facility");
            entity.Property(e => e.PhfmcFacility).HasColumnName("PHFMC_facility");
            entity.Property(e => e.PmhiFacility).HasColumnName("PMHI_facility");
            entity.Property(e => e.Psbi).HasColumnName("psbi");
            entity.Property(e => e.Sc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sc");
            entity.Property(e => e.Services247).HasColumnName("services_24_7");
            entity.Property(e => e.TehsilCode).HasMaxLength(50);
            entity.Property(e => e.TehsilId).HasColumnName("tehsil_id");
            entity.Property(e => e.UcId).HasColumnName("uc_id");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("Invoice");

            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Product");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.ProductName).HasMaxLength(500);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.ToTable("Request");

            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.PricePerUnit).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RequestedQuantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdatedQuantity).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<RequestMaster>(entity =>
        {
            entity.ToTable("RequestMaster");

            entity.Property(e => e.AdminId).HasMaxLength(450);
            entity.Property(e => e.RequestIdentifier).HasMaxLength(50);
            entity.Property(e => e.RequestStatus).HasMaxLength(50);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.ToTable("Stock");

            entity.Property(e => e.Batch).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.ManufacturingDate).HasColumnType("datetime");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<StockOut>(entity =>
        {
            entity.ToTable("StockOut");

            entity.Property(e => e.ApprovedQuantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Batch).HasMaxLength(500);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.LastAvailableQuantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Rate).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.RequestedQuantity).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.ToTable("Vendor");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(128);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(128);
            entity.Property(e => e.VendorName).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
