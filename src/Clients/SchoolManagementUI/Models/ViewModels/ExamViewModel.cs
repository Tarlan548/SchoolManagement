namespace SchoolManagementUI.Models.ViewModels;
public record ExamViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid LessonId { get; set; }
    public string LessonName { get; set; } = string.Empty;
    public Guid StudentId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public DateTime ExamDate { get; set; }
    public string? ClassLevel { get; set; }
    public int ExamResult { get; set; }
}
