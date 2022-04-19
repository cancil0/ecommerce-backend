using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ApiLogConfiguration : IEntityTypeConfiguration<ApiLog>
    {
        public void Configure(EntityTypeBuilder<ApiLog> builder)
        {
            #region Table
            builder.ToTable("apilog", "system");
            builder.HasComment("Holds api logs");
            builder.HasKey(x => x.ApiLogId);
            #endregion

            #region Relations

            #endregion

            #region Properties
            builder.Property(s => s.ApiLogId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("apilogid");

            builder.Property(s => s.UserName)
                .IsRequired()
                .HasColumnOrder(2)
                .HasColumnName("username");

            builder.Property(s => s.StatusCode)
                .IsRequired()
                .HasColumnType("numeric")
                .HasPrecision(3)
                .HasColumnOrder(3)
                .HasColumnName("statuscode");

            builder.Property(s => s.Method)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(4)
                .HasColumnName("method");

            builder.Property(s => s.ServiceName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(5)
                .HasColumnName("servicename");

            builder.Property(s => s.RouteUrl)
                .IsRequired()
                .HasColumnType("varchar")
                .HasColumnOrder(6)
                .HasColumnName("routeurl");

            builder.Property(s => s.Request)
               .HasColumnType("text")
               .HasDefaultValue(null)
               .HasColumnOrder(7)
               .HasColumnName("request");

            builder.Property(s => s.Response)
                .HasColumnType("text")
                .HasDefaultValue(null)
                .HasColumnOrder(8)
                .HasColumnName("response");

            builder.Property(s => s.Duration)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(9)
                .HasColumnName("duration");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(10)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(11)
                .HasColumnName("createdtime");
            #endregion
        }
    }
}
