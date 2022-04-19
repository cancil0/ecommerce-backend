using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            #region Table
            builder.ToTable("userrole", "system");
            builder.HasComment("Holds user's roles");
            builder.HasKey(x => new { x.UserId, x.RoleId });
            builder.HasQueryFilter(x => !x.User.IsDeleted);
            #endregion

            #region Relations
            builder.HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);
            #endregion

            #region Properties
            builder.Property(s => s.UserId)
                .IsRequired()
                .HasColumnOrder(1)
                .HasColumnName("userid");

            builder.Property(s => s.RoleId)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("roleid");
            #endregion

        }
    }
}
