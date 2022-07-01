using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Concrete
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) {}
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
