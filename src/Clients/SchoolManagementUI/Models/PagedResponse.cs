namespace SchoolManagementUI.Models;

public class PagedResponse<T> : BasePagedResponse
{
    public List<T> Data { get; set; } = null!;
}
