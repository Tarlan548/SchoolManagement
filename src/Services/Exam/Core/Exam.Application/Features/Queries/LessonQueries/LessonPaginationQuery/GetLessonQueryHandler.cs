using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.DTOs;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Queries.LessonQueries.LessonPaginationQuery;

public class GetLessonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetLessonQueryRequest, PagedResult<GetLessonQueryResponse>>
{
    public async Task<PagedResult<GetLessonQueryResponse>> Handle(GetLessonQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Lesson>().GetAllPagingQueryableAsync
                     (x =>
                        (string.IsNullOrEmpty(request.Name) || x.Name == request.Name) &&
                        (request.ClassLevel == null || x.ClassLevel == request.ClassLevel),
                        currentPage: request.CurrentPage, pageSize: request.PageSize, orderBy: x => x.OrderBy(x => x.Name)
                     );
        return mapper.Map<PagedResult<GetLessonQueryResponse>>(result);
    }
}
