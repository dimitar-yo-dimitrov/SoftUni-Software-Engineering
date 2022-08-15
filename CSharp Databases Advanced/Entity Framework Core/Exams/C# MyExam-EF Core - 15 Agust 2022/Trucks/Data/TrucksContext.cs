using Trucks.Data.Models;

namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;

    public class TrucksContext : DbContext
    {
        public TrucksContext() { }

        public TrucksContext(DbContextOptions options)
            : base(options) { }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientTruck> ClientsTrucks { get; set; }
        public virtual DbSet<Despatcher> Despatchers { get; set; }
        public virtual DbSet<Truck> Trucks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }

            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite PK of mapping entity
            modelBuilder.Entity<ClientTruck>(c =>
            {
                // Define PK
                c.HasKey(ct => new
                {
                    ct.ClientId,
                    ct.TruckId
                });
            });
        }
    }
}
