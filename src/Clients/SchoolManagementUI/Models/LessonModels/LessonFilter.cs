namespace SchoolManagementUI.Models.LessonModels;
public record LessonFilter
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string? Name { get; set; }
    public int? ClassLevel { get; set; }
}
