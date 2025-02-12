using MediatR;

namespace Exam.Application.Features.Commands.LessonCommands.CreateLesson
{
    public sealed record CreateLessonCommandRequest : IRequest<Unit>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int ClassLevel { get; set; }
    }
}