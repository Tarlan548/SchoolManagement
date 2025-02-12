using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.DTOs;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Queries.TeacherQueries;

public class GetTeacherQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetTeacherQueryRequest, PagedResult<GetTeacherQueryResponse>>
{
    public async Task<PagedResult<GetTeacherQueryResponse>> Handle(GetTeacherQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Teacher>().GetAllPagingQueryableAsync
            (x =>
               (string.IsNullOrEmpty(request.FirstName) || x.FirstName == request.FirstName) &&
               (string.IsNullOrEmpty(request.LastName) || x.LastName == request.LastName),
               currentPage: request.CurrentPage, pageSize: request.PageSize
            );
        return mapper.Map<PagedResult<GetTeacherQueryResponse>>(result);
    }
}