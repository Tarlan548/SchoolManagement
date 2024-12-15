using MediatR;

namespace Exam.Application.Features.Queries.LessonQueries.LessonGetAllQuery;

public class GetAllLessonQueryRequest : IRequest<IList<GetAllLessonQueryResponse>>
{

}