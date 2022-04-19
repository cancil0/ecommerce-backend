using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            #region Table
            builder.ToTable("address", "entity");
            builder.HasComment("Holds users and purchases adresses");
            builder.HasKey(x => x.AddressId);
            #endregion

            #region Relations
            builder.HasOne(x => x.User)
                    .WithMany(x => x.Addresses);
            #endregion

            #region Properties

            builder.Property(s => s.AddressId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("addressid");

            builder.Property(s => s.AddressType)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(1)
                .HasColumnOrder(2)
                .HasColumnName("addresstype");

            builder.Property(s => s.Country)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(3)
                .HasColumnName("country");

            builder.Property(s => s.Province)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(4)
                .HasColumnName("province");

            builder.Property(s => s.District)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(75)
                .HasColumnOrder(5)
                .HasColumnName("district");

            builder.Property(s => s.AddressInfo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(75)
                .HasColumnOrder(6)
                .HasColumnName("addressinfo");

            builder.Property(s => s.MobileNo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(13)
                .HasColumnOrder(7)
                .HasColumnName("mobileno");

            builder.Property(s => s.IsDefault)
                .IsRequired()
                .HasColumnType("boolean")
                .HasDefaultValue(false)
                .HasColumnOrder(8)
                .HasColumnName("isdefault");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(9)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(10)
                .HasColumnName("createdtime");

            builder.Property(s => s.CreatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(11)
                .HasColumnName("createdby");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("numeric")
                .HasColumnOrder(12)
                .HasColumnName("updateddate");

            builder.Property(s => s.UpdatedTime)
                .HasColumnType("numeric")
                .HasColumnOrder(13)
                .HasColumnName("updatedtime");

            builder.Property(s => s.UpdatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(14)
                .HasColumnName("updatedby");
            #endregion

        }
    }
}
