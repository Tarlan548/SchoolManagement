using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Queries.StudentQueries.StudentGetAllQuery;

public class GetAllStudentQueryMapper : Profile
{
    public GetAllStudentQueryMapper()
    {
        CreateMap<Student, GetAllStudentQueryResponse>().ReverseMap();
    }
}
