using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyStore.Core.Domain;

namespace MyStore.Infrastructure.EF
{
    public class MyStoreContext : DbContext
    {
        private readonly IOptions<SqlOptions> _sqlOptions;
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public MyStoreContext(IOptions<SqlOptions> sqlOptions)
        {
            _sqlOptions = sqlOptions;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            if (_sqlOptions.Value.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase("MyStore");
                
                return;
            }

            optionsBuilder.UseSqlServer(_sqlOptions.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}