namespace Exam.Application.DTOs;
public class PagedResult<T>
{
    public IList<T> Data { get; set; }
    public Page PageInfo { get; set; }

    public PagedResult(IList<T> data, Page pageInfo)
    {
        Data = data;
        PageInfo = pageInfo;
    }
    public PagedResult() : this((IList<T>)new List<T>(), new Page()) { }
}
