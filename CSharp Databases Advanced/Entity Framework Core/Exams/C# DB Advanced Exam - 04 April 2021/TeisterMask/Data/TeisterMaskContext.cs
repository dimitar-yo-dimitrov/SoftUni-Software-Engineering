
namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;

    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<EmployeeTask> EmployeesTasks { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<Task> Tasks { get; set; }

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
            modelBuilder.Entity<EmployeeTask>(e =>
            {
                // Define PK
                e.HasKey(et => new
                {
                    et.EmployeeId,
                    et.TaskId
                });
            });
        }
    }
}