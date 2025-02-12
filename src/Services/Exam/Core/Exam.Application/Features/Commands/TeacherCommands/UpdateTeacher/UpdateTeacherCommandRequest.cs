using MediatR;

namespace Exam.Application.Features.Commands.TeacherCommands.UpdateTeacher
{
    public sealed record UpdateTeacherCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}