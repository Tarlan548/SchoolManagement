using AutoMapper;
using Exam.Application.DTOs;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Queries.StudentQueries.StudentPaginationQuery;
public class GetStudentQueryMapper : Profile
{
    public GetStudentQueryMapper()
    {
        CreateMap<Student, GetStudentQueryResponse>();

        CreateMap<PagedResult<Student>, PagedResult<GetStudentQueryResponse>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
            .ForMember(dest => dest.PageInfo, opt => opt.Ignore());
    }
}
