using FluentValidation;

namespace Exam.Application.Features.Commands.ExamCommands.CreateExam;

public class CreateExamCommandValidator : AbstractValidator<CreateExamCommandRequest>
{
    public CreateExamCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithName("Name");

        RuleFor(x => x.LessonId)
            .NotEmpty()
            .NotNull()
            .WithName("Lesson Id");

        RuleFor(x => x.StudentId)
            .NotEmpty()
            .NotNull()
            .WithName("Student Id");

        RuleFor(x => x.ExamDate)
            .NotEmpty()
            .NotNull()
            .WithName("Exam Date");

        RuleFor(x => x.ExamResult)
            .NotEmpty()
            .NotNull()
            .WithName("Exam Result");
    }
}
