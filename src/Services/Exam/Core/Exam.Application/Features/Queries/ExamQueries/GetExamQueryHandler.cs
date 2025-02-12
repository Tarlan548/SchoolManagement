using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Features.Queries.ExamQueries;

public class GetExamQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetExamQueryRequest, PagedResult<GetExamQueryResponse>>
{
    public async Task<PagedResult<GetExamQueryResponse>> Handle(GetExamQueryRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Domain.Entities.Exam>().GetAllPagingQueryableAsync
            (x =>
               (string.IsNullOrEmpty(request.Name) || x.Name == request.Name) &&
               (string.IsNullOrEmpty(request.LessonName) || x.Lesson.Name == request.LessonName) &&
               (string.IsNullOrEmpty(request.StudentName) || x.Student.FirstName == request.StudentName) &&
               (string.IsNullOrEmpty(request.ExamDate.ToString()) || x.ExamDate == request.ExamDate),
               include: query => query
                        .Include(x => x.Lesson)
                        .Include(x => x.Student),
               currentPage: request.CurrentPage, pageSize: request.PageSize
            );
        return mapper.Map<PagedResult<GetExamQueryResponse>>(result);
    }
}
