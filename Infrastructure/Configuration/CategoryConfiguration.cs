using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Table
            builder.ToTable("category", "entity");
            builder.HasComment("Holds categories");
            builder.HasKey(x => x.CategoryId);
            #endregion

            #region Relations
            #endregion

            #region Properties
            builder.Property(s => s.CategoryId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1)
                .HasColumnName("categoryid");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .HasColumnOrder(2)
                .HasColumnName("name");

           builder.Property(s => s.ParentCategoryId)
                .HasColumnOrder(3)
                .HasColumnName("parentcategoryid");
            #endregion

        }
    }
}
