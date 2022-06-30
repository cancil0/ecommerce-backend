using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(ContextConfiguration.ConnectionString)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

    public static class ContextConfiguration
    {
        public static string ConnectionString { get; set; }
    }
}
