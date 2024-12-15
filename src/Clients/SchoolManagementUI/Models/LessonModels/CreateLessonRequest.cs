namespace SchoolManagementUI.Models.LessonModels;

public sealed record CreateLessonRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}
