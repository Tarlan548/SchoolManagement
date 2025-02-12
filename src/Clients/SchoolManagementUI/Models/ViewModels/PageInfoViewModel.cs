namespace SchoolManagementUI.Models.ViewModels;

public record PageInfoViewModel
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalRowCount { get; set; }
    public int TotalPageCount { get; set; }
    public int Skip { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
}
