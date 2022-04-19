using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ApiConfiguration : IEntityTypeConfiguration<Api>
    {
        public void Configure(EntityTypeBuilder<Api> builder)
        {
            #region Table
            builder.ToTable("api", "system");
            builder.HasComment("Holds api");
            builder.HasKey(x => x.ApiId);
            builder.HasAlternateKey(x => x.ApiRoute);
            #endregion

            #region Relations
            #endregion

            #region Properties
            builder.Property(s => s.ApiId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("apiid");

            builder.Property(s => s.ApiRoute)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .HasColumnName("apiroute");
            #endregion

        }
    }
}
