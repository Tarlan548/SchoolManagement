using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Queries.LessonQueries.LessonGetAllQuery;

internal class GetAllLessonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllLessonQueryRequest, IList<GetAllLessonQueryResponse>>
{
    public async Task<IList<GetAllLessonQueryResponse>> Handle(GetAllLessonQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Lesson>().GetAllAsync(x => !x.IsDeleted);
        var map = mapper.Map<IList<GetAllLessonQueryResponse>>(result);
        return map;
    }
}