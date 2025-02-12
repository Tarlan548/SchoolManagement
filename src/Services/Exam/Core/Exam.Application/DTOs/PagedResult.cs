namespace Exam.Application.DTOs;
public class PagedResult<T>
{
    public List<T> Data { get; set; }
    public Page PageInfo { get; set; }

    public PagedResult(List<T> data, Page pageInfo)
    {
        Data = data;
        PageInfo = pageInfo;
    }
    public PagedResult() : this((List<T>)new List<T>(), new Page()) { }
}
