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
            builder.HasAlternateKey(x => x.RegistrationNo);
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
                .HasColumnOrder(3)
                .HasColumnName("feedbackcount");

            builder.Property(s => s.RegistrationNo)
                .HasColumnType("numeric")
                .HasColumnOrder(4)
                .HasColumnName("registrationno");

            builder.Property(s => s.IsDeleted)
                .HasColumnType("boolean")
                .HasColumnOrder(5)
                .HasColumnName("isdeleted");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(6)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(7)
                .HasColumnName("createdtime");

            builder.Property(s => s.CreatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(8)
                .HasColumnName("createdby");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("numeric")
                .HasColumnOrder(9)
                .HasColumnName("updateddate");

            builder.Property(s => s.UpdatedTime)
                .HasColumnType("numeric")
                .HasColumnOrder(10)
                .HasColumnName("updatedtime");

            builder.Property(s => s.UpdatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(11)
                .HasColumnName("updatedby");
            #endregion
        }
    }
}
