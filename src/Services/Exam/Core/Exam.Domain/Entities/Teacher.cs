using Exam.Domain.Common;

namespace Exam.Domain.Entities;

public class Teacher : EntityBase<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ICollection<LessonTeacher> LessonTeachers { get; set; } = new List<LessonTeacher>();
}
