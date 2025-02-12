using Exam.Application.DTOs;
using MediatR;

namespace Exam.Application.Features.Queries.ExamQueries;

public class GetExamQueryRequest : IRequest<PagedResult<GetExamQueryResponse>>
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public string? Name { get; set; }
    public string? LessonName { get; set; }
    public string? StudentName { get; set; }
    public DateTime? ExamDate { get; set; }
}