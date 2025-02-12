namespace SchoolManagementUI.Models.TeacherModels;

public sealed record UpdateTeacherRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
