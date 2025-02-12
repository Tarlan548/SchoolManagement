using MediatR;

namespace Exam.Application.Features.Commands.LessonCommands.UpdateLesson;
public sealed record UpdateLessonCommandRequest : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}