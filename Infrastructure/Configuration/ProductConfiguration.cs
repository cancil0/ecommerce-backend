using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            #region Table
            builder.ToTable("product", "entity");
            builder.HasComment("Holds products");
            builder.HasKey(x => x.ProductId);
            #endregion

            #region Relations
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products);
            #endregion

            #region Properties
            builder.Property(s => s.ProductId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("productid");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(2)
                .HasColumnName("name");

            builder.Property(s => s.Model)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(3)
                .HasColumnName("model");

            builder.Property(s => s.Brand)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .HasColumnOrder(4)
                .HasColumnName("brand");

            builder.Property(s => s.IsDeleted)
                .IsRequired()
                .HasColumnType("boolean")
                .HasColumnOrder(5)
                .HasColumnName("isdeleted");

            builder.Property(s => s.CreatedDate)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(6)
                .HasColumnName("createddate");

            builder.Property(s => s.CreatedTime)
                .IsRequired()
                .HasColumnType("numeric")
                .HasColumnOrder(7)
                .HasColumnName("createdtime");

            builder.Property(s => s.CreatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(8)
                .HasColumnName("createdby");

            builder.Property(s => s.UpdatedDate)
                .HasColumnType("numeric")
                .HasColumnOrder(9)
                .HasColumnName("updateddate");

            builder.Property(s => s.UpdatedTime)
                .HasColumnType("numeric")
                .HasColumnOrder(10)
                .HasColumnName("updatedtime");

            builder.Property(s => s.UpdatedBy)
                .HasColumnType("varchar")
                .HasColumnOrder(11)
                .HasColumnName("updatedby");
            #endregion
        }
    }
}
