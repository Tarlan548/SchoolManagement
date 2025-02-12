namespace SchoolManagementUI.Models.ViewModels;
public record ErrorViewModel
{
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public string Detail { get; set; } = string.Empty;
}
