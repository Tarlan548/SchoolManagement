using MediatR;
namespace Exam.Application.Features.Commands.StudentCommands.UpdateStudent;
public class UpdateStudentCommandRequest : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int ClassLevel { get; set; }
}