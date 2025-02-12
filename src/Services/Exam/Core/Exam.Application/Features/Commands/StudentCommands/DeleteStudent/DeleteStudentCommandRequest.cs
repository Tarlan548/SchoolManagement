using MediatR;

namespace Exam.Application.Features.Commands.StudentCommands.DeleteStudent
{
    public sealed record DeleteStudentCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}