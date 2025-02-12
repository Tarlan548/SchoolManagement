using FluentValidation;

namespace Exam.Application.Features.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherCommandValidator : AbstractValidator<UpdateTeacherCommandRequest>
{
    public UpdateTeacherCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .WithName("First Name");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .WithName("Last Name");
    }
}