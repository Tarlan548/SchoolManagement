using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Queries.LessonQueries.LessonGetAllQuery;

public class GetAllLessonQueryMapper : Profile
{
    public GetAllLessonQueryMapper()
    {
        CreateMap<Lesson, GetAllLessonQueryResponse>().ReverseMap();
    }
}
