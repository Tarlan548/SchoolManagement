using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherCommandMapper : Profile
{
    public UpdateTeacherCommandMapper()
    {
        CreateMap<UpdateTeacherCommandRequest, Teacher>().ReverseMap();
    }
}
