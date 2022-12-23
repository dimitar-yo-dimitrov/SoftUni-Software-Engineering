using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        // Testing
        public StudentSystemContext()
        {

        }

        // Judge
        public StudentSystemContext(DbContextOptions options)
        : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        // Establish a connection to the SQL Server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // True -> Connection string is already set
            // False -> Connection string isn't set
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        // Define rules for creating DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite PK of mapping entity
            modelBuilder.Entity<StudentCourse>(e =>
            {
                // Define PK
                e.HasKey(sc => new
                {
                    sc.StudentId,
                    sc.CourseId
                });
            });
        }
    }
}
