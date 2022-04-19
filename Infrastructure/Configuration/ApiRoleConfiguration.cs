using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ApiRoleConfiguration : IEntityTypeConfiguration<ApiRole>
    {
        public void Configure(EntityTypeBuilder<ApiRole> builder)
        {
            #region Table
            builder.ToTable("apirole", "system");
            builder.HasComment("Holds api's roles");
            builder.HasKey(x => new { x.ApiId, x.RoleId });
            #endregion

            #region Relations
            builder.HasOne(x => x.Api)
                .WithMany(x => x.ApiRoles)
                .HasForeignKey(x => x.ApiId);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.ApiRoles)
                .HasForeignKey(x => x.RoleId);
            #endregion

            #region Properties
            builder.Property(s => s.ApiId)
                .IsRequired()
                .HasColumnOrder(1)
                .HasColumnName("apiid");

            builder.Property(s => s.RoleId)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("roleid");
            #endregion

        }
    }
}
