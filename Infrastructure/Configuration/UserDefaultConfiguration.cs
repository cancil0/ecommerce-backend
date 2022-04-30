using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserDefaultConfiguration : IEntityTypeConfiguration<UserDefault>
    {
        public void Configure(EntityTypeBuilder<UserDefault> builder)
        {
            #region Table
            builder.ToTable("userdefault", "entity");
            builder.HasKey(x => x.UserDefaultId);
            builder.HasQueryFilter(x => !x.User.IsDeleted);
            #endregion

            #region Relations
            #endregion

            #region Properties
            builder.Property(s => s.UserDefaultId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("userdefaultid");

            builder.Property(s => s.UserId)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("userid");

            builder.Property(s => s.CultereInfo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(3)
                .HasColumnName("cultereinfo");

            builder.Property(s => s.Theme)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(4)
                .HasColumnName("theme");
            #endregion
        }
    }
}
