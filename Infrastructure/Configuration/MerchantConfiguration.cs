using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MerchantConfiguration : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            #region Table
            builder.ToTable("merchant", "entity");
            builder.HasComment("Holds merchants");
            builder.HasKey(x => x.MerchantId);
            #endregion

            #region Relations
            builder.HasOne(x => x.Address)
                .WithMany(x => x.Merchants);
            #endregion

            #region Properties
            builder.Property(s => s.MerchantId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("merchantid");

            builder.Property(s => s.MerchantName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(2)
                .HasColumnName("merchantname");

            builder.Property(s => s.MerchantPoint)
                .HasPrecision(2,1)
                .HasColumnType("numeric")
                .HasColumnOrder(3)
                .HasColumnName("merchantpoint");

            builder.Property(s => s.FeedbackCount)
                .HasColumnType("numeric")
                .HasColumnOrder(4)
                .HasColumnName("feedbackcount");

            builder.Property(s => s.RegistrationNo)
                .HasColumnType("numeric")
                .HasColumnOrder(5)
                .HasColumnName("registrationno");

            builder.Property(s => s.IsDeleted)
                .HasColumnType("boolean")
                .HasColumnOrder(6)
                .HasColumnName("isdeleted");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(7)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(8)
                .HasColumnName("createdtime");

            builder.Property(s => s.CreatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(9)
                .HasColumnName("createdby");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("numeric")
                .HasColumnOrder(10)
                .HasColumnName("updateddate");

            builder.Property(s => s.UpdatedTime)
                .HasColumnType("numeric")
                .HasColumnOrder(11)
                .HasColumnName("updatedtime");

            builder.Property(s => s.UpdatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(12)
                .HasColumnName("updatedby");
            #endregion
        }
    }
}
