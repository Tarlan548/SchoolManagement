using FluentValidation;

namespace Exam.Application.Features.Commands.StudentCommands.CreateStudent;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommandRequest>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .WithName("First Name");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .WithName("Last Name");

        RuleFor(x => x.ClassLevel)
            .NotEmpty()
            .NotNull()
            .WithName("Class Level");
    }
}
