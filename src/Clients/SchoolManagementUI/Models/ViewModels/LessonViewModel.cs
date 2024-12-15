namespace SchoolManagementUI.Models.ViewModels;

public record LessonViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}
