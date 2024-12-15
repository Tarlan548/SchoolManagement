using FluentValidation;

namespace Exam.Application.Features.Commands.LessonCommands.CreateLesson;

public class CreateLessonCommandValidator : AbstractValidator<CreateLessonCommandRequest>
{
    public CreateLessonCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithName("Name");

        RuleFor(x => x.ClassLevel)
            .NotEmpty()
            .NotNull()
            .WithName("Class Level");
    }
}
