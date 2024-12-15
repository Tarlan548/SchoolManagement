using Exam.Domain.Common;

namespace Exam.Domain.Entities;

public class Lesson : EntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
    public ICollection<LessonTeacher> LessonTeachers { get; set; } = new List<LessonTeacher>();
}
