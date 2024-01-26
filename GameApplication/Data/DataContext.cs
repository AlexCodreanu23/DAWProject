using GameApplication.Models;
using Microsoft.EntityFrameworkCore;
using GameApplication.Models;

namespace GameApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<SystemRequirements> SystemRequirements { get; set; }
        public DbSet<Developers> Developers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
