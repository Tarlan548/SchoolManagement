using MediatR;

namespace Exam.Application.Features.Queries.StudentQueries.StudentGetAllQuery;
public class GetAllStudentQueryRequest : IRequest<IList<GetAllStudentQueryResponse>>
{
}