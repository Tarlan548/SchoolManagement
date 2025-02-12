namespace SchoolManagementUI.Models.StudentModels;

public sealed record CreateStudentRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}
