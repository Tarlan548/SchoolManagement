namespace SchoolManagementUI.Models.StudentModels;

public record StudentFilter
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? ClassLevel { get; set; }
}
