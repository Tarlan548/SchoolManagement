namespace SchoolManagementUI.Models.LessonModels;
public record LessonFilter
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Name { get; set; }
    public int? ClassLevel { get; set; }
}
