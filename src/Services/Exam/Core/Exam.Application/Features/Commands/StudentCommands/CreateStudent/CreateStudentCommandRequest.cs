using MediatR;

namespace Exam.Application.Features.Commands.StudentCommands.CreateStudent
{
    public class CreateStudentCommandRequest : IRequest<Unit>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int ClassLevel { get; set; }
    }
}