using AutoMapper;
using Exam.Application.DTOs;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Queries.LessonQueries.LessonPaginationQuery;

public class GetLessonQueryMapper : Profile
{
    public GetLessonQueryMapper()
    {
        CreateMap<Lesson, GetLessonQueryResponse>();

        CreateMap<PagedResult<Lesson>, PagedResult<GetLessonQueryResponse>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
            .ForMember(dest => dest.PageInfo, opt => opt.Ignore());
    }
}
