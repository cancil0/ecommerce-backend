using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CarouselConfiguration : IEntityTypeConfiguration<Carousel>
    {
        public void Configure(EntityTypeBuilder<Carousel> builder)
        {
            #region Table
            builder.ToTable("carousel", "entity");
            builder.HasComment("Holds Home Page's carousel");
            builder.HasKey(x => x.CarouselId);
            builder.HasQueryFilter(x => !x.IsDeleted);
            #endregion

            #region Relations

            #endregion

            #region Properties
            builder.Property(s => s.CarouselId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("cartid");

            builder.Property(s => s.IsDeleted)
                .HasColumnType("boolean")
                .HasColumnOrder(2)
                .HasColumnName("isdeleted");

            builder.Property(s => s.Title)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(3)
                .HasColumnName("title");

            builder.Property(s => s.Description)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(4)
                .HasColumnName("description");

            builder.Property(s => s.LinkToNavigate)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(5)
                .HasColumnName("linktonavigate");

            builder.Property(s => s.ImagePath)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(6)
                .HasColumnName("imagepath");

            builder.Property(s => s.ImageOrder)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(7)
                .HasColumnName("imageorder");
            #endregion
        }
    }
}
