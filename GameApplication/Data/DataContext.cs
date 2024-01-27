using GameApplication.Models;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GameDeveloper>()
            .HasOne(gd => gd.Game)
            .WithMany(g => g.GameDevelopers)
            .HasForeignKey(gd => gd.GameId);

            modelBuilder.Entity<GameDeveloper>()
                .HasOne(gd => gd.Developers)
                .WithMany(d => d.GameDevelopers)
                .HasForeignKey(gd => gd.DeveloperId);
        }
    }
}
