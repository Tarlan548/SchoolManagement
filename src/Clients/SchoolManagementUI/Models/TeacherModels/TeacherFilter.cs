namespace SchoolManagementUI.Models.TeacherModels;

public sealed record TeacherFilter
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
