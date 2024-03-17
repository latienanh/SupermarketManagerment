using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.Domain.Entities.Identity;
using Supermarket.Domain.Entities.SupermarketEntities;
using Supermarket.Domain.Entities.Token;
using Attribute = Supermarket.Domain.Entities.SupermarketEntities.Attribute;

namespace Supermarket.Infastructure
{
    public class SuperMarketDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Domain.Entities.SupermarketEntities.Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<AttributeValue> AttributeValues { get; set; } = null!;
        public virtual DbSet<Batch> Batches { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; } = null!;
        public virtual DbSet<MemberShipType> MemberShipTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<StockIn> StockIns { get; set; } = null!;
        public virtual DbSet<StockInDetail> StockInDetails { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<UnitConversion> UnitConversions { get; set; } = null!;
        public virtual DbSet<Variant> Variants { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=Latienanh;Initial Catalog=SupermarketManagement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Expriaton)
                    .HasColumnType("datetime")
                    .HasColumnName("expriaton");
                entity.Property(e => e.UserId).HasColumnName("userId");
                 entity.Property(e => e.Token).HasColumnName("token");

                 entity.HasOne(d => d.AppUser)
                     .WithOne(d => d.RefreshToken)
                     .HasForeignKey<RefreshToken>(d => d.UserId);
            });
            modelBuilder.Entity<Domain.Entities.SupermarketEntities.Attribute>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttributeName)
                    .HasMaxLength(50)
                    .HasColumnName("attributeName");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<AttributeValue>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttributeId).HasColumnName("attributeId");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.AttributeValue1)
                    .HasMaxLength(50)
                    .HasColumnName("attributeValue");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.AttributeValues)
                    .HasForeignKey(d => d.AttributeId)
                    .HasConstraintName("FK_AttributeValues_Attributes2");
            });

            modelBuilder.Entity<Batch>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BatchNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("batchNumber");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ExpiryDate)
                    .HasColumnType("date")
                    .HasColumnName("expiryDate");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ManufacturingDate)
                    .HasColumnType("date")
                    .HasColumnName("manufacturingDate");


                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(150)
                    .HasColumnName("categoryName");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ParentId).HasColumnName("parentId");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_Categories_Categories");
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("code");

                entity.Property(e => e.CouponDescripiton).HasColumnName("couponDescripiton");

                entity.Property(e => e.CouponEndDate)
                    .HasColumnType("date")
                    .HasColumnName("couponEndDate");

                entity.Property(e => e.CouponStartDate)
                    .HasColumnType("date")
                    .HasColumnName("couponStartDate");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.DiscountType).HasColumnName("discountType");

                entity.Property(e => e.DiscountValue).HasColumnName("discountValue");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.FullName)
                    .HasMaxLength(101)
                    .HasColumnName("fullName")
                    .HasComputedColumnSql("(([firstName]+' ')+[lastName])", false);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");

                entity.Property(e => e.MembershipTypeId).HasColumnName("membershipTypeId");


                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength();

                entity.HasOne(d => d.MembershipType)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MembershipTypeId)
                    .HasConstraintName("FK_Customers_membershipType");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");


                entity.Property(e => e.CustomerId).HasColumnName("customerID");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");


                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("date")
                    .HasColumnName("invoiceDate");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .HasColumnName("paymentMethod");

                entity.Property(e => e.PaymentStatus).HasColumnName("paymentStatus");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Invoices_Customers");
            });

            modelBuilder.Entity<InvoiceDetail>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InvoiceId).HasColumnName("invoiceId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TotalPrice).HasColumnName("totalPrice");

                entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

                entity.Property(e => e.VariantId).HasColumnName("variantId");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_Invoices");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_Products");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_InvoiceDetails_Variants");
            });

            modelBuilder.Entity<MemberShipType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(10)
                    .HasColumnName("barCode")
                    .IsFixedLength();

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");


                entity.Property(e => e.ProductImage)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("productImage");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductSlug)
                    .IsUnicode(false)
                    .HasColumnName("productSlug");

                entity.Property(e => e.Quantity).HasColumnName("quantity");


                entity.HasMany(d => d.Batches)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductBatch",
                        l => l.HasOne<Batch>().WithMany().HasForeignKey("BatchId")
                            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductBatches_Batches"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductBatches_Products"),
                        j =>
                        {
                            j.HasKey("ProductId", "BatchId");

                            j.ToTable("ProductBatches");

                            j.IndexerProperty<int>("ProductId").HasColumnName("productId");

                            j.IndexerProperty<int>("BatchId").HasColumnName("batchId");
                        });

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("FK_productCategories_Categories"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_productCategories_Products"),
                        j =>
                        {
                            j.HasKey("ProductId", "CategoryId");

                            j.ToTable("productCategories");

                            j.IndexerProperty<int>("ProductId").HasColumnName("productId");

                            j.IndexerProperty<int>("CategoryId").HasColumnName("categoryId");
                        });

                entity.HasMany(d => d.Coupons)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCoupon",
                        l => l.HasOne<Coupon>().WithMany().HasForeignKey("CouponId")
                            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductCoupons_Coupons"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId")
                            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ProductCoupons_Products"),
                        j =>
                        {
                            j.HasKey("ProductId", "CouponId");

                            j.ToTable("ProductCoupons");

                            j.IndexerProperty<int>("ProductId").HasColumnName("productId");

                            j.IndexerProperty<int>("CouponId").HasColumnName("couponId");
                        });
            });

            modelBuilder.Entity<StockIn>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("date")
                    .HasColumnName("entryDate");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Note).HasColumnName("note");

                entity.Property(e => e.SupplierId).HasColumnName("supplierId");

                entity.Property(e => e.TotalOrderValue).HasColumnName("totalOrderValue");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.StockIns)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_StockIns_Suppliers");
            });

            modelBuilder.Entity<StockInDetail>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.QuantityReceived).HasColumnName("quantityReceived");

                entity.Property(e => e.StockInId).HasColumnName("stockInId");

                entity.Property(e => e.TotalValueReceived).HasColumnName("totalValueReceived");

                entity.Property(e => e.UnitPriceReceived).HasColumnName("unitPriceReceived");

                entity.Property(e => e.VariantId).HasColumnName("variantId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StockInDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_StockInDetails_Products");

                entity.HasOne(d => d.StockIn)
                    .WithMany(p => p.StockInDetails)
                    .HasForeignKey(d => d.StockInId)
                    .HasConstraintName("FK_StockInDetails_StockIns");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.StockInDetails)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_StockInDetails_Variants");
            });


            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");



                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("phoneNumber")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UnitConversion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");



                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("unitName");

                entity.Property(e => e.VariantId).HasColumnName("variantId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UnitConversions)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_UnitConversions_Products");

                entity.HasOne(d => d.Variant)
                    .WithMany(p => p.UnitConversions)
                    .HasForeignKey(d => d.VariantId)
                    .HasConstraintName("FK_UnitConversions_Variants");
            });

            modelBuilder.Entity<Variant>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AttributeValueId).HasColumnName("attributeValueId");

                entity.Property(e => e.BuyingPrice).HasColumnName("buyingPrice");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.ImageProductVariant)
                    .IsUnicode(false)
                    .HasColumnName("imageProductVariant");

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");


                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SalePrice).HasColumnName("salePrice");

                entity.Property(e => e.Sku)
                    .HasMaxLength(10)
                    .HasColumnName("sku")
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.HasOne(d => d.AttributeValue)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(d => d.AttributeValueId)
                    .HasConstraintName("FK_Variants_AttributeValues");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Variants)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_VaritionOptions_Products");

                entity.HasMany(d => d.Batches)
                    .WithMany(p => p.Variants)
                    .UsingEntity<Dictionary<string, object>>(
                        "VariantBatch",
                        l => l.HasOne<Batch>().WithMany().HasForeignKey("BatchId")
                            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_VaritionBatches_Batches"),
                        r => r.HasOne<Variant>().WithMany().HasForeignKey("VariantId")
                            .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_VariantBatches_Variants"),
                        j =>
                        {
                            j.HasKey("VariantId", "BatchId").HasName("PK_VaritionBatches");

                            j.ToTable("VariantBatches");

                            j.IndexerProperty<int>("VariantId").HasColumnName("variantId");

                            j.IndexerProperty<int>("BatchId").HasColumnName("batchId");
                        });
            });
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.CreateBy).HasColumnName("createBy");
                entity.Property(e => e.DeleteBy).HasColumnName("deleteBy");
                entity.Property(e => e.CreateTime)
                    .HasColumnType("date")
                    .HasColumnName("createTime");
                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("date")
                    .HasColumnName("modifiedTime");
                entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.FullName)
                    .HasMaxLength(101)
                    .HasColumnName("fullName")
                    .HasComputedColumnSql("(([firstName]+' ')+[lastName])", false);

                entity.Property(e => e.IsDelete)
                    .HasColumnName("isDelete")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("lastName");
            });
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasOne(e => e.Employee)
                    .WithOne(x => x.AppUsers)
                    .HasForeignKey<Employee>(x => x.UserId)
                    .HasConstraintName("FK_Employees_AppUsers");

                entity.HasMany(d => d.Attributes)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e=>e.CreateBy)
                    .HasConstraintName("FK_Attributes_AppUsers_Create");
                entity.HasMany(d => d.AttributeValues)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_AttributeValues_AppUsers_Create");
                entity.HasMany(d => d.StockIns)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_StockIns_AppUsers_Create");
                entity.HasMany(d => d.Suppliers)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Suppliers_AppUsers_Create");
                entity.HasMany(d => d.Variants)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Variants_AppUsers_Create");
                entity.HasMany(d => d.Batches)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Batches_AppUsers_Create");
                entity.HasMany(d => d.UnitConversions)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_UnitConversions_AppUsers_Create");
                entity.HasMany(d => d.Invoices)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Invoices_AppUsers_Create");
                entity.HasMany(d => d.Customers)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Customers_AppUsers_Create");
                entity.HasMany(d => d.Products)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Products_AppUsers_Create");

                entity.HasMany(d => d.Categories)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Categories_AppUsers_Create");
                entity.HasMany(d => d.Coupons)
                    .WithOne(e => e.AppUsers)
                    .HasForeignKey(e => e.CreateBy)
                    .HasConstraintName("FK_Coupons_AppUsers_Create");
            });
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var tableName = entityType.GetTableName();
                    if (tableName.StartsWith("AspNet"))
                    {
                        entityType.SetTableName(tableName.Substring(6));
                    }
                }
            }


        }
    }
}
