namespace SchoolManagementUI.Models.TeacherModels;
public sealed record CreateTeacherRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
