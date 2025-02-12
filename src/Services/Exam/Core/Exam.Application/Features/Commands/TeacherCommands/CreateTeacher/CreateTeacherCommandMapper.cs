using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherCommandMapper : Profile
{
    public CreateTeacherCommandMapper()
    {
        CreateMap<CreateTeacherCommandRequest, Teacher>();
    }
}