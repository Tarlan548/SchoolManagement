using AutoMapper;
using Exam.Application.DTOs;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Queries.TeacherQueries;

public class GetTeacherQueryMapper : Profile
{
    public GetTeacherQueryMapper()
    {
        CreateMap<Teacher, GetTeacherQueryResponse>();

        CreateMap<PagedResult<Teacher>, PagedResult<GetTeacherQueryResponse>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
            .ForMember(dest => dest.PageInfo, opt => opt.Ignore());
    }
}