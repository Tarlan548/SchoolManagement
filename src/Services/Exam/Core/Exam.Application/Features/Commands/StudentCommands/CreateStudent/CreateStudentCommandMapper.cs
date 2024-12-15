using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Commands.StudentCommands.CreateStudent;

public class CreateStudentCommandMapper : Profile
{
    public CreateStudentCommandMapper()
    {
        CreateMap<CreateStudentCommandRequest, Student>().ReverseMap();
    }
}
