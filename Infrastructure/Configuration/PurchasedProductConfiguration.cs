using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PurchasedProductConfiguration : IEntityTypeConfiguration<PurchasedProduct>
    {
        public void Configure(EntityTypeBuilder<PurchasedProduct> builder)
        {
            #region Table
            builder.ToTable("purchased_product", "entity");
            builder.HasComment("Holds pursches's products");
            builder.HasKey(x => new { x.ProductId, x.PurchaseId });
            #endregion

            #region Relations
            builder.HasOne(x => x.Purchase)
                .WithMany(x => x.PurchasedProducts)
                .HasForeignKey(x => x.PurchaseId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.PurchasedProducts)
                .HasForeignKey(x => x.ProductId);
            #endregion

            #region Properties
            builder.Property(s => s.PurchaseId)
                .IsRequired()
                .HasColumnOrder(1)
                .HasColumnName("purchaseid");

            builder.Property(s => s.ProductId)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("productid");
            #endregion

        }
    }
}
