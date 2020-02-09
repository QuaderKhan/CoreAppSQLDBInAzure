using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreAppSQLDBInAzure.Models
{
    public partial class ECommerceContext : DbContext
    {
        public ECommerceContext()
        {
        }

        public ECommerceContext(DbContextOptions<ECommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCatagory> ProductCatagory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.ProductBrand)
                    .HasColumnName("productBrand")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductCatagory).HasColumnName("productCatagory");

                entity.Property(e => e.ProductCode)
                    .HasColumnName("productCode")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductImageUrl)
                    .HasColumnName("productImageUrl")
                    .HasMaxLength(100);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.HasOne(d => d.ProductCatagoryNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCatagory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCatagory");
            });

            modelBuilder.Entity<ProductCatagory>(entity =>
            {
                entity.HasKey(e => e.CatagoryId);

                entity.Property(e => e.CatagoryId).HasColumnName("catagoryId");

                entity.Property(e => e.Catagory)
                    .IsRequired()
                    .HasColumnName("catagory")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
