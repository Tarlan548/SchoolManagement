namespace Exam.Application.DTOs;
public class Page
{
    public const int DefaultCurrentPage = 1;
    public const int DefaultPageSize = 10;

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalRowCount { get; set; }

    public int TotalPageCount => (int)Math.Ceiling((double)TotalRowCount / PageSize);
    public int Skip => (CurrentPage - 1) * PageSize;
    public bool HasNextPage => CurrentPage < TotalPageCount;
    public bool HasPreviousPage => CurrentPage > 1;

    public Page() : this(DefaultCurrentPage, DefaultPageSize, 0) { }

    public Page(int totalRowCount) : this(DefaultCurrentPage, DefaultPageSize, totalRowCount) { }

    public Page(int pageSize, int totalRowCount) : this(DefaultCurrentPage, pageSize, totalRowCount) { }

    public Page(int currentPage, int pageSize, int totalRowCount)
    {
        CurrentPage = currentPage > 0 ? currentPage : DefaultCurrentPage;
        PageSize = pageSize > 0 ? pageSize : DefaultPageSize;
        TotalRowCount = totalRowCount >= 0 ? totalRowCount : 0;
    }
}