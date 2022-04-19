using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=ECommerce;Integrated Security=true;Pooling=true;")
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
