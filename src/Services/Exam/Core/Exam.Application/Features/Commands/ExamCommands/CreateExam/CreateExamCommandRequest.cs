using MediatR;

namespace Exam.Application.Features.Commands.ExamCommands.CreateExam;

public sealed record CreateExamCommandRequest : IRequest<Unit>
{
    public string Name { get; set; } = string.Empty;
    public string LessonId { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public DateTime ExamDate { get; set; }
    public int ExamResult { get; set; }
}