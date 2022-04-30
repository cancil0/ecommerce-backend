using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region Table
            builder.ToTable("user", "entity");
            builder.HasComment("Holds user's information");
            builder.HasKey(x => x.UserId);
            builder.HasQueryFilter(x => !x.IsDeleted);
            #endregion

            #region Relations
            builder.HasOne(x => x.Cart)
                .WithOne(x => x.User)
                .HasForeignKey<Cart>(x => x.UserId);

            builder.HasOne(x => x.UserDefault)
                .WithOne(x => x.User)
                .HasForeignKey<UserDefault>(x => x.UserId);
            #endregion

            #region Properties
            builder.Property(s => s.UserId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("userid");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(2)
                .HasColumnName("name");

            builder.Property(s => s.SurName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(3)
                .HasColumnName("surname");

            builder.Property(s => s.UserName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnOrder(4)
                .HasColumnName("username");

            builder.Property(s => s.Email)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(75)
                .HasColumnOrder(5)
                .HasColumnName("email");

            builder.Property(s => s.MobileNo)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(6)
                .HasColumnName("mobileno");

            builder.Property(s => s.Gender)
                .HasColumnType("varchar")
                .HasColumnOrder(7)
                .HasColumnName("gender");

            builder.Property(s => s.BirthDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasPrecision(8)
                .HasColumnOrder(8)
                .HasColumnName("birthdate");

            builder.Property(s => s.Password)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(9)
                .HasColumnName("password");

            builder.Property(s => s.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasColumnOrder(10)
                .HasColumnName("isdeleted");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(11)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(12)
                .HasColumnName("createdtime");

            builder.Property(s => s.CreatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(13)
                .HasColumnName("createdby");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("numeric")
                .HasColumnOrder(14)
                .HasColumnName("updateddate");

            builder.Property(s => s.UpdatedTime)
                .HasColumnType("numeric")
                .HasColumnOrder(15)
                .HasColumnName("updatedtime");

            builder.Property(s => s.UpdatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(16)
                .HasColumnName("updatedby");
            #endregion
        }
    }
}
