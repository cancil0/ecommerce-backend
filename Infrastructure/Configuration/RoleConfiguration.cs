using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            #region Table
            builder.ToTable("role", "system");
            builder.HasComment("Holds roles");
            builder.HasKey(x => x.RoleId);
            builder.HasAlternateKey(x => x.RoleName);
            #endregion

            #region Relations
            #endregion

            #region Properties
            builder.Property(s => s.RoleId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("roleid");

            builder.Property(s => s.RoleName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(2)
                .HasColumnName("rolename");
            #endregion

        }
    }
}
