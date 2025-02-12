namespace SchoolManagementUI.Models.ViewModels;

public sealed record StudentViewModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}
