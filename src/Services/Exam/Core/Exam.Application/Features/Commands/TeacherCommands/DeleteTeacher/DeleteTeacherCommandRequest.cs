using MediatR;

namespace Exam.Application.Features.Commands.TeacherCommands.DeleteTeacher
{
    public class DeleteTeacherCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}