using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            #region Table
            builder.ToTable("cart_product", "entity");
            builder.HasComment("Holds cart's products");
            builder.HasKey(x => new { x.CartId, x.ProductId });
            #endregion

            #region Relations
            builder.HasOne(x => x.Cart)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x.CartId);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.CartProducts)
                .HasForeignKey(x => x.ProductId);
            #endregion

            #region Properties
            builder.Property(s => s.CartId)
                .IsRequired()
                .HasColumnOrder(1)
                .HasColumnName("cartid");

            builder.Property(s => s.ProductId)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("productid");
            #endregion

        }
    }
}
