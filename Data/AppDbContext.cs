using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentRecordSystem.Data.Entities;
using StudentRecordSystem.Models;

namespace StudentRecordSystem.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<ModuleInstructor> ModuleInstructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Required for Identity

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            // Seed default roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Student", NormalizedName = "STUDENT" },
                new IdentityRole { Id = "3", Name = "Instructor", NormalizedName = "INSTRUCTOR" }
            );

            // Composite PK for Enrollment
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            // Composite PK for ModuleInstructor
            modelBuilder.Entity<ModuleInstructor>()
                .HasKey(mi => new { mi.ModuleId, mi.InstructorId });

            // Enrollment relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // ModuleInstructor relationships
            modelBuilder.Entity<ModuleInstructor>()
                .HasOne(mi => mi.Module)
                .WithMany(m => m.ModuleInstructors)
                .HasForeignKey(mi => mi.ModuleId);

            modelBuilder.Entity<ModuleInstructor>()
                .HasOne(mi => mi.Instructor)
                .WithMany(i => i.ModuleInstructors)
                .HasForeignKey(mi => mi.InstructorId);
        }
    }
}