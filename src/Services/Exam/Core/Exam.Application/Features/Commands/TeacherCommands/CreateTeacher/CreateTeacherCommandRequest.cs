using MediatR;

namespace Exam.Application.Features.Commands.TeacherCommands.CreateTeacher;

public sealed record CreateTeacherCommandRequest : IRequest<Unit>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}