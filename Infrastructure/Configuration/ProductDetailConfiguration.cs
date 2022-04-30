using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            #region Table
            builder.ToTable("productdetail", "entity");
            builder.HasComment("Holds product's details");
            builder.HasKey(x => x.ProductDetailId);
            #endregion

            #region Relations
            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductDetails);

            builder.HasOne(x => x.Merchant)
                .WithMany(x => x.ProductDetails);
            #endregion

            #region Properties
            builder.Property(s => s.ProductDetailId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("productdetailid");

            builder.Property(s => s.Count)
                .IsRequired()
                .HasColumnType("numeric")
                .HasPrecision(10)
                .HasColumnOrder(2)
                .HasColumnName("count");

            builder.Property(s => s.Price)
                .IsRequired()
                .HasColumnType("numeric")
                .HasPrecision(15, 2)
                .HasColumnOrder(3)
                .HasColumnName("price");

            builder.Property(s => s.Detail)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(4000)
                .HasColumnOrder(4)
                .HasColumnName("detail");

            builder.Property(s => s.Color)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(5)
                .HasColumnName("color");

            builder.Property(s => s.Size)
                .HasColumnType("numeric")
                .HasMaxLength(250)
                .HasColumnOrder(6)
                .HasColumnName("size");

            builder.Property(s => s.ClickCount)
                .HasColumnType("numeric")
                .HasMaxLength(250)
                .HasColumnOrder(7)
                .HasColumnName("clickcount");

            builder.Property(s => s.PurchaseCount)
                .HasColumnType("numeric")
                .HasMaxLength(250)
                .HasColumnOrder(8)
                .HasColumnName("purchasecount");


            #endregion
        }
    }
}
