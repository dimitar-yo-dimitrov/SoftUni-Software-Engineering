using Artillery.Data.Models;

namespace Artillery.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ArtilleryContext : DbContext
    {
        public ArtilleryContext() { }

        public ArtilleryContext(DbContextOptions options)
            : base(options) { }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<CountryGun> CountriesGuns { get; set; }

        public virtual DbSet<Gun> Guns { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<Shell> Shells { get; set; }

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
            modelBuilder.Entity<CountryGun>(e =>
            {
                // Define PK
                e.HasKey(cg => new
                {
                    cg.CountryId,
                    cg.GunId
                });
            });
        }
    }
}
