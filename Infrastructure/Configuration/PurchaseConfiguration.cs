using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            #region Table
            builder.ToTable("purchase", "entity");
            builder.HasComment("Holds purschases");
            builder.HasKey(x => x.PurchaseId);
            #endregion

            #region Relations
            builder.HasOne(x => x.Address)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Purchases);
            #endregion

            #region Properties
            builder.Property(s => s.PurchaseId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("purchaseid");

            builder.Property(s => s.TotalPrice)
                .IsRequired()
                .HasPrecision(15, 2)
                .HasColumnOrder(2)
                .HasColumnName("totalprice");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("timestamp without time zone")
                .HasColumnOrder(3)
                .HasColumnName("createddate");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("timestamp without time zone")
                .HasColumnOrder(4)
                .HasColumnName("updateddate");
            #endregion

        }
    }
}
