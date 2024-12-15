using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Persistence.Configurations;

internal class LessonTeacherConfiguration : IEntityTypeConfiguration<Domain.Entities.LessonTeacher>
{
    public void Configure(EntityTypeBuilder<LessonTeacher> builder)
    {
        builder.HasKey(lt => new { lt.LessonId, lt.TeacherId });

        builder.HasOne(lt => lt.Lesson)
            .WithMany(l => l.LessonTeachers)
            .HasForeignKey(lt => lt.LessonId);

        builder.HasOne(lt => lt.Teacher)
            .WithMany(t => t.LessonTeachers)
            .HasForeignKey(lt => lt.TeacherId);

        builder.ToTable("LessonTeachers");
    }
}
