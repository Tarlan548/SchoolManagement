using FluentValidation;

namespace Exam.Application.Features.Commands.LessonCommands.UpdateLesson;

public class UpdateLessonCommandValidator : AbstractValidator<UpdateLessonCommandRequest>
{
    public UpdateLessonCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithName("Lesson name");

        RuleFor(x => x.ClassLevel)
            .NotEmpty()
            .NotNull()
            .WithName("Class level");
    }
}
