namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;
    using SoftJail.Data.Models;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public virtual DbSet<Prisoner> Prisoners { get; set; }

        public virtual DbSet<Officer> Officers { get; set; }

        public virtual DbSet<Cell> Cells { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Mail> Mails { get; set; }

        public virtual DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Composite PK of mapping entity
            builder.Entity<OfficerPrisoner>(e =>
            {
                // Define PK
                e.HasKey(cg => new
                {
                    cg.PrisonerId,
                    cg.OfficerId
                });
            });
        }
    }
}