using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Features.Queries.LessonQueries.LessonGetAllQuery;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Queries.StudentQueries.StudentGetAllQuery;

public class GetAllStudentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllStudentQueryRequest, IList<GetAllStudentQueryResponse>>
{
    public async Task<IList<GetAllStudentQueryResponse>> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Student>().GetAllAsync();
        var map = mapper.Map<IList<GetAllStudentQueryResponse>>(result);
        return map;
    }
}
