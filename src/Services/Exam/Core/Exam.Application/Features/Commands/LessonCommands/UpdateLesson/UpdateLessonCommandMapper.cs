using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Commands.LessonCommands.UpdateLesson;

public class UpdateLessonCommandMapper : Profile
{
    public UpdateLessonCommandMapper()
    {
        CreateMap<UpdateLessonCommandRequest, Lesson>().ReverseMap();
    }
}
