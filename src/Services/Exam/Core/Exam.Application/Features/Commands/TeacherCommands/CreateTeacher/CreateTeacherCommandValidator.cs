using FluentValidation;

namespace Exam.Application.Features.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherCommandValidator : AbstractValidator<CreateTeacherCommandRequest>
{
    public CreateTeacherCommandValidator()
    {
        RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .WithName("First Name");

        RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .WithName("Last Name");
    }
}
