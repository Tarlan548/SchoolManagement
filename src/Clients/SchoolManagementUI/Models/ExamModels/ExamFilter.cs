namespace SchoolManagementUI.Models.ExamModels;
public record ExamFilter
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string? Name { get; set; }
    public string? LessonName { get; set; }
    public string? StudentName { get; set; }
    public string? ClassLevel { get; set; }
    public DateTime? ExamDate { get; set; }
}
