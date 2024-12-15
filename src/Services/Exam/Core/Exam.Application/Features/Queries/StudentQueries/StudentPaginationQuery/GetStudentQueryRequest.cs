using Exam.Application.DTOs;
using MediatR;

namespace Exam.Application.Features.Queries.StudentQueries.StudentPaginationQuery
{
    public sealed record GetStudentQueryRequest : IRequest<PagedResult<GetStudentQueryResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? ClassLevel { get; set; }
    }
}