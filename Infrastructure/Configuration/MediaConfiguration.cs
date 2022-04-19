using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            #region Table
            builder.ToTable("media", "entity");
            builder.HasComment("Holds medias");
            builder.HasKey(x => x.MediaId);
            #endregion

            #region Relations
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Medias);
            #endregion

            #region Properties
            builder.Property(s => s.MediaId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("mediaid");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(2)
                .HasColumnName("name");

            builder.Property(s => s.Path)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(3)
                .HasColumnName("path");

            builder.Property(s => s.Order)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnType("numeric")
                .HasPrecision(2)
                .HasColumnOrder(4)
                .HasColumnName("order");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(5)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(6)
                .HasColumnName("createdtime");

            builder.Property(s => s.CreatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(7)
                .HasColumnName("createdby");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("numeric")
                .HasColumnOrder(8)
                .HasColumnName("updateddate");

            builder.Property(s => s.UpdatedTime)
                .HasColumnType("numeric")
                .HasColumnOrder(9)
                .HasColumnName("updatedtime");

            builder.Property(s => s.UpdatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(10)
                .HasColumnName("updatedby");
            #endregion
        }
    }
}
