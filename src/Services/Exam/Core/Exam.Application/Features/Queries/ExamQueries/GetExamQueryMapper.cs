using AutoMapper;
using Exam.Application.DTOs;

namespace Exam.Application.Features.Queries.ExamQueries;
public class GetExamQueryMapper : Profile
{
    public GetExamQueryMapper()
    {
        CreateMap<Domain.Entities.Exam, GetExamQueryResponse>()
            .ForMember(scr => scr.StudentName, desc => desc.MapFrom(x => x.Student.FirstName + " " + x.Student.LastName));


        CreateMap<PagedResult<Domain.Entities.Exam>, PagedResult<GetExamQueryResponse>>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Data))
            .ForMember(dest => dest.PageInfo, opt => opt.Ignore());
    }
}
