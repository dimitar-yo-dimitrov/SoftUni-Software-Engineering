using VaporStore.Data.Models;

namespace Footballers.Data
{
    using Microsoft.EntityFrameworkCore;

    public class FootballersContext : DbContext
    {
        public FootballersContext() { }

        public FootballersContext(DbContextOptions options)
            : base(options) { }

        public virtual DbSet<Coach> Coaches { get; set; }

        public virtual DbSet<Footballer> Footballers { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<TeamFootballer> TeamsFootballers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            optionsBuilder
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite PK of mapping entity
            modelBuilder.Entity<TeamFootballer>(t =>
            {
                // Define PK
                t.HasKey(tf => new
                {
                    tf.TeamId,
                    tf.FootballerId
                });
            });
        }
    }
}
