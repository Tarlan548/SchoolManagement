using FluentValidation;

namespace Exam.Application.Features.Commands.ExamCommands.UpdateExam;

public class UpdateExamCommandValidator : AbstractValidator<UpdateExamCommandRequest>
{
    public UpdateExamCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithName("Id");

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
