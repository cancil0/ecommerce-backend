using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            #region Table
            builder.ToTable("cart", "entity");
            builder.HasComment("Holds user's cart");
            builder.HasKey(x => x.CartId);
            builder.HasQueryFilter(x => !x.User.IsDeleted);
            #endregion

            #region Relations

            #endregion

            #region Properties
            builder.Property(s => s.CartId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("cartid");

            builder.Property(s => s.UserId)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("userid");
            #endregion
        }
    }
}
