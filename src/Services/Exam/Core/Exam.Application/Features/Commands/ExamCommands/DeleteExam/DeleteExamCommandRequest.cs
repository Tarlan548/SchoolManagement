using MediatR;

namespace Exam.Application.Features.Commands.ExamCommands.DeleteExam
{
    public class DeleteExamCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}