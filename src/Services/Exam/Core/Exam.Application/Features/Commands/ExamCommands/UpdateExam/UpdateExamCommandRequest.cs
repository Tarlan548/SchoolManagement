using MediatR;

namespace Exam.Application.Features.Commands.ExamCommands.UpdateExam;
public sealed record UpdateExamCommandRequest : IRequest<Unit>
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string LessonId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public DateTime ExamDate { get; set; }
    public int ExamResult { get; set; }
}