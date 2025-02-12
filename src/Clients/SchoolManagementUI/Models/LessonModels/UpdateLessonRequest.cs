namespace SchoolManagementUI.Models.LessonModels;

public sealed record UpdateLessonRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}
