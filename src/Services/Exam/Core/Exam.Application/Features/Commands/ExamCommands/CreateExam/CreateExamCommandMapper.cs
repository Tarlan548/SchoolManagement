using AutoMapper;

namespace Exam.Application.Features.Commands.ExamCommands.CreateExam;

public class CreateExamCommandMapper : Profile
{
    public CreateExamCommandMapper()
    {
        CreateMap<Domain.Entities.Exam, CreateExamCommandRequest>()
            .AfterMap((src, dest) =>
            {
                dest.LessonId = src.LessonId.ToString();
                dest.StudentId = src.StudentId.ToString();
            })
            .ReverseMap();
    }
}
