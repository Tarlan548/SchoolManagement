using MediatR;

namespace Exam.Application.Features.Commands.LessonCommands.DeleteLesson
{
    public sealed record DeleteLessonCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}