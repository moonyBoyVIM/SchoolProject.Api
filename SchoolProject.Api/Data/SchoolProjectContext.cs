using Microsoft.EntityFrameworkCore;
using SchoolProject.Api.Entitiies.StudetnsEntities;
using SchoolProject.Api.Entitiies.Teachers;

namespace SchoolProject.Api.Data;

public class SchoolProjectContext(DbContextOptions<SchoolProjectContext> options)
            : DbContext(options)
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<CategoryStudent> CategoryStudents => Set<CategoryStudent>();

    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<CategoryTeacher> CategoryTeachers => Set<CategoryTeacher>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryStudent>()
                    .HasData(new { Id = 1, Name = "Junior School" },
                             new { Id = 2, Name = "Middle School" },
                             new { Id = 3, Name = "High School" });

        modelBuilder.Entity<CategoryTeacher>()
                    .HasData(new { Id = 1, Name = "Math" },
                             new { Id = 2, Name = "Biology" },
                             new { Id = 3, Name = "Chemistry" },
                             new { Id = 4, Name = "History" },
                             new { Id = 5, Name = "Physics" },
                             new { Id = 6, Name = "Literature" });
    }
}