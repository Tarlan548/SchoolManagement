using AutoMapper;
using Exam.Application.Features.Commands.ExamCommands.CreateExam;

namespace Exam.Application.Features.Commands.ExamCommands.UpdateExam;

public class UpdateExamCommandMapper : Profile
{
    public UpdateExamCommandMapper()
    {
        CreateMap<Domain.Entities.Exam, UpdateExamCommandRequest>()
            .ForMember(dest => dest.LessonId, opt => opt.MapFrom(src => src.LessonId.ToString()))
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId.ToString()))
            .ReverseMap();
    }
}
