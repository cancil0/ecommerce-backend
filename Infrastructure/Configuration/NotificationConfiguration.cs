using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            #region Table
            //Excluded from db for now
            builder.ToTable(x => x.ExcludeFromMigrations());
            #endregion

            #region Reletaions
            #endregion

            #region Properties
            builder.Property(s => s.NotificationId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1);

            builder.Property(s => s.Type)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(2);

            builder.Property(s => s.TypeSymbol)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(3);

            builder.Property(s => s.Details)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .HasColumnOrder(4);

            builder.Property(s => s.Status)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnOrder(5);

            builder.Property(s => s.Date)
                .IsRequired()
                .HasColumnType("timestamp without time zone")
                .HasColumnOrder(6);

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(7)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(8)
                .HasColumnName("createdtime");

            builder.Property(s => s.CreatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(9)
                .HasColumnName("createdby");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("numeric")
                .HasColumnOrder(10)
                .HasColumnName("updateddate");

            builder.Property(s => s.UpdatedTime)
                .HasColumnType("numeric")
                .HasColumnOrder(11)
                .HasColumnName("updatedtime");

            builder.Property(s => s.UpdatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(12)
                .HasColumnName("updatedby");
            #endregion

        }
    }
}
