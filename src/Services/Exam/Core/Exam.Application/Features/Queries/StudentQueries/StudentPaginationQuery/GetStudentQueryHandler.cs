using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.DTOs;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Queries.StudentQueries.StudentPaginationQuery;

public class GetStudentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetStudentQueryRequest, PagedResult<GetStudentQueryResponse>>
{
    public async Task<PagedResult<GetStudentQueryResponse>> Handle(GetStudentQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Student>().GetAllPagingQueryableAsync
    (x =>
       (string.IsNullOrEmpty(request.FirstName) || x.FirstName == request.FirstName) &&
       (string.IsNullOrEmpty(request.LastName) || x.LastName == request.LastName) &&
       (request.ClassLevel == null || x.ClassLevel == request.ClassLevel),
       currentPage: request.CurrentPage, pageSize: request.PageSize, orderBy: x => x.OrderBy(x => x.FirstName)
    );
        return mapper.Map<PagedResult<GetStudentQueryResponse>>(result);
    }
}
