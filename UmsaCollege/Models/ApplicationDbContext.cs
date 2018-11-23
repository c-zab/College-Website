using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class ApplicationDbContext : DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseStudents> CourseStudent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<CourseStudents>()
                .HasKey(bc => new { bc.CourseID, bc.StudentID });
            modelBuilder.Entity<CourseStudents>()
                .HasOne(bc => bc.course)
                .WithMany(b => b.CourseStudents)
                .HasForeignKey(bc => bc.CourseID);
            modelBuilder.Entity<CourseStudents>()
                .HasOne(bc => bc.student)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(bc => bc.StudentID);
        }
    }
}
