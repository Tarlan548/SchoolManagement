using System.Reflection;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Persistence.Context;

public class SchoolDbContext(DbContextOptions<SchoolDbContext> options) : DbContext(options)
{

    public virtual required DbSet<Teacher> Teachers { get; set; }
    public virtual required DbSet<Domain.Entities.Exam> Exams { get; set; }
    public virtual required DbSet<Lesson> Lessons { get; set; }
    public virtual required DbSet<Student> Students { get; set; }
    public virtual required DbSet<LessonTeacher> LessonTeachers { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}