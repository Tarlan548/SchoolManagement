using Exam.Application.DTOs;
using MediatR;

namespace Exam.Application.Features.Queries.LessonQueries.LessonPaginationQuery
{
    public sealed record GetLessonQueryRequest : IRequest<PagedResult<GetLessonQueryResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public int? ClassLevel { get; set; }
    }
}