using efcore_migrations.Data.Mappings;
using efcore_migrations.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore_migrations.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
