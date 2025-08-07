using HelloApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloApi.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ✅ Seed Teacher
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher { Id = 1, Name = "Default Teacher" }
            );

            // ✅ Seed Course linked to Teacher
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, CourseName = "AI", TeacherId = 1 },
                new Course { Id = 2, CourseName = "ML", TeacherId = 1 }
            );

            // ✅ Seed Students linked to Courses
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Alice", CourseId = 1 },
                new Student { Id = 2, Name = "Bob", CourseId = 2 }
            );
        }

    }
}
