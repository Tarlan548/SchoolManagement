using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.LessonCommands.DeleteLesson;

public class DeleteLessonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteLessonCommandRequest, Unit>
{
    public async Task<Unit> Handle(DeleteLessonCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Lesson>().GetAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Lesson");
        await unitOfWork.GetWriteRepository<Lesson>().SoftDeleteAsync(result, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}