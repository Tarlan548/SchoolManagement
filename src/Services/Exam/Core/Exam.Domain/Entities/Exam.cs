using Exam.Domain.Common;

namespace Exam.Domain.Entities;

public class Exam : EntityBase<Guid>
{
    public string Name { get; set; } = string.Empty;
    public Guid LessonId { get; set; }
    public Lesson Lesson { get; set; } = null!;
    public Guid StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public DateTime ExamDate { get; set; }
    public int ExamResult { get; set; }
}