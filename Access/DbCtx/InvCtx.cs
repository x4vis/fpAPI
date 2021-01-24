using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace fpAPI.Access.DbCtx
{
    public partial class InvCtx : DbContext
    {
        public InvCtx()
        {
        }

        public InvCtx(DbContextOptions<InvCtx> options)
            : base(options)
        {
        }

        public virtual DbSet<Buy> Buys { get; set; }
        public virtual DbSet<BuyDetail> BuyDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Devolution> Devolutions { get; set; }
        public virtual DbSet<DevolutionDetail> DevolutionDetails { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<FiscalClient> FiscalClients { get; set; }
        public virtual DbSet<MeasurementUnit> MeasurementUnits { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<OfficeProduct> OfficeProducts { get; set; }
        public virtual DbSet<OfficeProductHistory> OfficeProductHistories { get; set; }
        public virtual DbSet<OfficeProvider> OfficeProviders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductExpense> ProductExpenses { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ProviderBank> ProviderBanks { get; set; }
        public virtual DbSet<ProviderContact> ProviderContacts { get; set; }
        public virtual DbSet<ProviderProduct> ProviderProducts { get; set; }
        public virtual DbSet<ProviderProductHistory> ProviderProductHistories { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<Subcategory> Subcategories { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=NgaMm.1613;database=inv_cont", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buy>(entity =>
            {
                entity.ToTable("Buy");

                entity.HasIndex(e => e.ProviderFk, "buy_provider_fk");

                entity.HasIndex(e => e.UserFk, "buy_user_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Iva)
                    .HasPrecision(20, 2)
                    .HasColumnName("iva");

                entity.Property(e => e.ProductsQty)
                    .HasColumnType("mediumint unsigned")
                    .HasColumnName("products_qty");

                entity.Property(e => e.ProviderFk).HasColumnName("provider_fk");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(20, 2)
                    .HasColumnName("subtotal");

                entity.Property(e => e.Total)
                    .HasPrecision(20, 2)
                    .HasColumnName("total");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.ProviderFkNavigation)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.ProviderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("buy_provider_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Buys)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("buy_user_fk");
            });

            modelBuilder.Entity<BuyDetail>(entity =>
            {
                entity.ToTable("Buy_Detail");

                entity.HasComment("A row per bought product");

                entity.HasIndex(e => e.BuyFk, "buydetail_buy_fk");

                entity.HasIndex(e => e.ProductFk, "buydetail_product_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BuyFk).HasColumnName("buy_fk");

                entity.Property(e => e.Iva)
                    .HasPrecision(20, 2)
                    .HasColumnName("iva");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(20, 2)
                    .HasColumnName("subtotal");

                entity.Property(e => e.Total)
                    .HasPrecision(20, 2)
                    .HasColumnName("total");

                entity.HasOne(d => d.BuyFkNavigation)
                    .WithMany(p => p.BuyDetails)
                    .HasForeignKey(d => d.BuyFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("buydetail_buy_fk");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.BuyDetails)
                    .HasForeignKey(d => d.ProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("buydetail_product_fk");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.HasComment("Product Categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("nombre")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.HasIndex(e => e.ClientFiscalFk, "client_fiscalclient_fk");

                entity.HasIndex(e => e.OfficeFk, "client_office_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientFiscalFk).HasColumnName("client_fiscal_fk");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.FirstNames)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("first_names")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Landline)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("landline")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.LastNames)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("last_names")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.MobilePhone)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("mobile_phone")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.OfficeFk).HasColumnName("office_fk");

                entity.HasOne(d => d.ClientFiscalFkNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientFiscalFk)
                    .HasConstraintName("client_fiscalclient_fk");

                entity.HasOne(d => d.OfficeFkNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.OfficeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("client_office_fk");
            });

            modelBuilder.Entity<Devolution>(entity =>
            {
                entity.ToTable("Devolution");

                entity.HasIndex(e => e.UserFk, "devolution_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ProductsQty)
                    .HasColumnType("mediumint unsigned")
                    .HasColumnName("products_qty");

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("reason")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Total)
                    .HasPrecision(20, 2)
                    .HasColumnName("total");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Devolutions)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("devolution_user");
            });

            modelBuilder.Entity<DevolutionDetail>(entity =>
            {
                entity.ToTable("Devolution_Detail");

                entity.HasComment("A row per returned product");

                entity.HasIndex(e => e.DevolutionFk, "devolutiondetail_devolution_fk");

                entity.HasIndex(e => e.ProductFk, "devolutiondetail_product_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DevolutionFk).HasColumnName("devolution_fk");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.Total)
                    .HasPrecision(20, 2)
                    .HasColumnName("total");

                entity.HasOne(d => d.DevolutionFkNavigation)
                    .WithMany(p => p.DevolutionDetails)
                    .HasForeignKey(d => d.DevolutionFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("devolutiondetail_devolution_fk");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.DevolutionDetails)
                    .HasForeignKey(d => d.ProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("devolutiondetail_product_fk");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.HasComment("Product Discounts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Qty)
                    .HasPrecision(10, 2)
                    .HasColumnName("qty");
            });

            modelBuilder.Entity<FiscalClient>(entity =>
            {
                entity.ToTable("Fiscal_Client");

                entity.HasIndex(e => e.Rfc, "rfc")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cp)
                    .HasColumnType("mediumint unsigned")
                    .HasColumnName("cp");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ExtNum)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("ext_num")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IntNum)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("int_num")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Neighborhood)
                    .HasColumnType("varchar(64)")
                    .HasColumnName("neighborhood")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("phone_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.RazonSocial)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("razon_social")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Rfc)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("rfc")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.State)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("state")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Street)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("street")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Town)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("town")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<MeasurementUnit>(entity =>
            {
                entity.ToTable("Measurement_Unit");

                entity.HasComment("Product Measurement Units");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(64)")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.MuKey)
                    .HasColumnType("varchar(16)")
                    .HasColumnName("mu_key")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("Office");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<OfficeProduct>(entity =>
            {
                entity.ToTable("Office_Product");

                entity.HasIndex(e => e.OfficeFk, "officeproduct_office_fk");

                entity.HasIndex(e => e.ProductFk, "officeproduct_product_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OfficeFk).HasColumnName("office_fk");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.SellPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("sell_price");

                entity.Property(e => e.Stock)
                    .HasPrecision(10, 2)
                    .HasColumnName("stock");

                entity.Property(e => e.Utility)
                    .HasPrecision(10, 2)
                    .HasColumnName("utility");

                entity.HasOne(d => d.OfficeFkNavigation)
                    .WithMany(p => p.OfficeProducts)
                    .HasForeignKey(d => d.OfficeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("officeproduct_office_fk");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.OfficeProducts)
                    .HasForeignKey(d => d.ProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("officeproduct_product_fk");
            });

            modelBuilder.Entity<OfficeProductHistory>(entity =>
            {
                entity.ToTable("Office_Product_History");

                entity.HasIndex(e => e.OfficeProductFk, "officeproducthistory_officeproduct_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OfficeProductFk).HasColumnName("office_product_fk");

                entity.Property(e => e.PriceUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("price_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SellPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("sell_price");

                entity.Property(e => e.Utility)
                    .HasPrecision(10, 2)
                    .HasColumnName("utility");

                entity.HasOne(d => d.OfficeProductFkNavigation)
                    .WithMany(p => p.OfficeProductHistories)
                    .HasForeignKey(d => d.OfficeProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("officeproducthistory_officeproduct_fk");
            });

            modelBuilder.Entity<OfficeProvider>(entity =>
            {
                entity.ToTable("Office_Provider");

                entity.HasIndex(e => e.OfficeFk, "officeprovider_office_fk");

                entity.HasIndex(e => e.ProviderFk, "officeprovider_provider_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OfficeFk).HasColumnName("office_fk");

                entity.Property(e => e.ProviderFk).HasColumnName("provider_fk");

                entity.HasOne(d => d.OfficeFkNavigation)
                    .WithMany(p => p.OfficeProviders)
                    .HasForeignKey(d => d.OfficeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("officeprovider_office_fk");

                entity.HasOne(d => d.ProviderFkNavigation)
                    .WithMany(p => p.OfficeProviders)
                    .HasForeignKey(d => d.ProviderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("officeprovider_provider_fk");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.HasIndex(e => e.DiscountFk, "product_discount_fk");

                entity.HasIndex(e => e.MesurementUnitFk, "product_measurementunit_fk");

                entity.HasIndex(e => e.SubcategoryFk, "product_subcategory_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("description")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.DiscountFk).HasColumnName("discount_fk");

                entity.Property(e => e.MesurementUnitFk).HasColumnName("mesurement_unit_fk");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Sku)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("sku")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.SubcategoryFk).HasColumnName("subcategory_fk");

                entity.Property(e => e.Weight)
                    .HasPrecision(10, 2)
                    .HasColumnName("weight");

                entity.HasOne(d => d.DiscountFkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.DiscountFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("product_discount_fk");

                entity.HasOne(d => d.MesurementUnitFkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MesurementUnitFk)
                    .HasConstraintName("product_measurementunit_fk");

                entity.HasOne(d => d.SubcategoryFkNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubcategoryFk)
                    .HasConstraintName("product_subcategory_fk");
            });

            modelBuilder.Entity<ProductExpense>(entity =>
            {
                entity.ToTable("Product_Expense");

                entity.HasIndex(e => e.ProductFk, "productexpense_product_fk");

                entity.HasIndex(e => e.UserFk, "productexpense_user_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Consumable)
                    .HasColumnName("consumable")
                    .HasDefaultValueSql("'0'")
                    .HasComment("if the product expense it was for other products (TRUE) or it leaves for others reasons");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Decrease)
                    .HasColumnName("decrease")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.Reason)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("reason")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.ProductExpenses)
                    .HasForeignKey(d => d.ProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productexpense_product_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.ProductExpenses)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("productexpense_user_fk");
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.ToTable("Provider");

                entity.HasIndex(e => e.ComercialName, "comercial_name")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.HasIndex(e => e.Rfc, "rfc")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ComercialName)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("comercial_name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Cp)
                    .HasColumnType("mediumint unsigned")
                    .HasColumnName("cp");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ExtNum)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("ext_num")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IntNum)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("int_num")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Neighborhood)
                    .HasColumnType("varchar(64)")
                    .HasColumnName("neighborhood")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PersonType)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasColumnName("person_type")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("phone_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasColumnName("rfc")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Street)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("street")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<ProviderBank>(entity =>
            {
                entity.ToTable("Provider_Bank");

                entity.HasComment("Provider´s banks");

                entity.HasIndex(e => e.ProviderFk, "providerbank_provider_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountHolder)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasColumnName("account_holder")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasColumnName("account_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Clabe).HasColumnName("clabe");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ProviderFk).HasColumnName("provider_fk");

                entity.HasOne(d => d.ProviderFkNavigation)
                    .WithMany(p => p.ProviderBanks)
                    .HasForeignKey(d => d.ProviderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("providerbank_provider_fk");
            });

            modelBuilder.Entity<ProviderContact>(entity =>
            {
                entity.ToTable("Provider_Contact");

                entity.HasComment("Provider´s contacts");

                entity.HasIndex(e => e.ProviderFk, "providercontact_provider_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnType("varchar(128)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.FirstNames)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("first_names")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.LastNames)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("last_names")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("phone_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Position)
                    .HasColumnType("varchar(64)")
                    .HasColumnName("position")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ProviderFk).HasColumnName("provider_fk");

                entity.HasOne(d => d.ProviderFkNavigation)
                    .WithMany(p => p.ProviderContacts)
                    .HasForeignKey(d => d.ProviderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("providercontact_provider_fk");
            });

            modelBuilder.Entity<ProviderProduct>(entity =>
            {
                entity.ToTable("Provider_Product");

                entity.HasIndex(e => e.ProductFk, "providerproduct_product_fk");

                entity.HasIndex(e => e.ProviderFk, "providerproduct_provider_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.ProviderFk).HasColumnName("provider_fk");

                entity.Property(e => e.SellPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("sell_price");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.ProviderProducts)
                    .HasForeignKey(d => d.ProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("providerproduct_product_fk");

                entity.HasOne(d => d.ProviderFkNavigation)
                    .WithMany(p => p.ProviderProducts)
                    .HasForeignKey(d => d.ProviderFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("providerproduct_provider_fk");
            });

            modelBuilder.Entity<ProviderProductHistory>(entity =>
            {
                entity.ToTable("Provider_Product_History");

                entity.HasIndex(e => e.ProviderProductFk, "providerproducthistory_providerproduct_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PriceUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("price_update")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ProviderProductFk).HasColumnName("provider_product_fk");

                entity.Property(e => e.SellPrice)
                    .HasPrecision(10, 2)
                    .HasColumnName("sell_price");

                entity.HasOne(d => d.ProviderProductFkNavigation)
                    .WithMany(p => p.ProviderProductHistories)
                    .HasForeignKey(d => d.ProviderProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("providerproducthistory_providerproduct_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mask).HasColumnName("mask");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(64)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.HasIndex(e => e.ClientFk, "sale_client_fk");

                entity.HasIndex(e => e.UserFk, "sale_user_fk");

                entity.HasIndex(e => e.TransactionNum, "transaction_num")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientFk).HasColumnName("client_fk");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Iva)
                    .HasPrecision(20, 2)
                    .HasColumnName("iva");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasDefaultValueSql("'0'")
                    .HasComment("FALSE if sale, TRUE if order");

                entity.Property(e => e.ProductsQty)
                    .HasColumnType("mediumint unsigned")
                    .HasColumnName("products_qty");

                entity.Property(e => e.Status)
                    .HasColumnType("varchar(64)")
                    .HasColumnName("status")
                    .HasComment("confirm or order")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(20, 2)
                    .HasColumnName("subtotal");

                entity.Property(e => e.Total)
                    .HasPrecision(20, 2)
                    .HasColumnName("total");

                entity.Property(e => e.TransactionNum).HasColumnName("transaction_num");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.ClientFkNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ClientFk)
                    .HasConstraintName("sale_client_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.UserFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sale_user_fk");
            });

            modelBuilder.Entity<SaleDetail>(entity =>
            {
                entity.ToTable("Sale_Detail");

                entity.HasComment("A row per sold product");

                entity.HasIndex(e => e.ProductFk, "saledetail_product_fk");

                entity.HasIndex(e => e.SaleFk, "saledetail_sale_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Iva)
                    .HasPrecision(20, 2)
                    .HasColumnName("iva");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.SaleFk).HasColumnName("sale_fk");

                entity.Property(e => e.Subtotal)
                    .HasPrecision(20, 2)
                    .HasColumnName("subtotal");

                entity.Property(e => e.TotaL)
                    .HasPrecision(20, 2)
                    .HasColumnName("totaL");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.ProductFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("saledetail_product_fk");

                entity.HasOne(d => d.SaleFkNavigation)
                    .WithMany(p => p.SaleDetails)
                    .HasForeignKey(d => d.SaleFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("saledetail_sale_fk");
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.ToTable("Subcategory");

                entity.HasComment("Product Subcategories");

                entity.HasIndex(e => e.CategoryFk, "subcategory_category_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryFk).HasColumnName("category_fk");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.CategoryFkNavigation)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CategoryFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subcategory_category_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.HasIndex(e => e.OfficeFk, "user_office_fk");

                entity.HasIndex(e => e.RoleFk, "user_rol_fk");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cp)
                    .HasColumnType("mediumint unsigned")
                    .HasColumnName("cp");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(128)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.ExtNum)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("ext_num")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.FirstNames)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("first_names")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.IntNum)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("int_num")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.LastNames)
                    .IsRequired()
                    .HasColumnType("varchar(255)")
                    .HasColumnName("last_names")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Neighborhood)
                    .HasColumnType("varchar(64)")
                    .HasColumnName("neighborhood")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.OfficeFk).HasColumnName("office_fk");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(32)")
                    .HasColumnName("phone_number")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Psw)
                    .IsRequired()
                    .HasColumnType("tinyblob")
                    .HasColumnName("psw");

                entity.Property(e => e.RoleFk).HasColumnName("role_fk");

                entity.Property(e => e.Street)
                    .HasColumnType("varchar(255)")
                    .HasColumnName("street")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_unicode_ci");

                entity.HasOne(d => d.OfficeFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OfficeFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_office_fk");

                entity.HasOne(d => d.RoleFkNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_rol_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
