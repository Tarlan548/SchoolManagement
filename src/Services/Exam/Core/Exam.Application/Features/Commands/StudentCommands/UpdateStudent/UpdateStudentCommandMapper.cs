using AutoMapper;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Commands.StudentCommands.UpdateStudent;

public class UpdateStudentCommandMapper : Profile
{
    public UpdateStudentCommandMapper()
    {
        CreateMap<UpdateStudentCommandRequest, Student>().ReverseMap();
    }
}
