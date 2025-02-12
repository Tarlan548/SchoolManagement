namespace SchoolManagementUI.Models.ExamModels;
public sealed record UpdateExamRequest
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LessonId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public DateTime ExamDate { get; set; }
    public int ExamResult { get; set; }
}
