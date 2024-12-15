using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Commands.LessonCommands.CreateLesson;

public class CreateLessonCommandMapper : Profile
{
    public CreateLessonCommandMapper()
    {
        CreateMap<CreateLessonCommandRequest, Lesson>().ReverseMap();
    }
}