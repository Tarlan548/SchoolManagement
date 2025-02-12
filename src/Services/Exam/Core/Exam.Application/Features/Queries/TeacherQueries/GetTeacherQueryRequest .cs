using Exam.Application.DTOs;
using MediatR;

namespace Exam.Application.Features.Queries.TeacherQueries
{
    public class GetTeacherQueryRequest : IRequest<PagedResult<GetTeacherQueryResponse>>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}