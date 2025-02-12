namespace Exam.Domain.Entities;

public class LessonTeacher
{
    public Guid LessonId { get; set; }
    public Lesson? Lesson { get; set; } = null!;
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;
}
