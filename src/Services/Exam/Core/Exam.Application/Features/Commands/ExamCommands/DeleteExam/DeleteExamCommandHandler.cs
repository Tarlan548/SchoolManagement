using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using MediatR;

namespace Exam.Application.Features.Commands.ExamCommands.DeleteExam;

public class DeleteExamCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteExamCommandRequest, Unit>
{
    public async Task<Unit> Handle(DeleteExamCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Domain.Entities.Exam>().GetAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Exam");
        await unitOfWork.GetWriteRepository<Domain.Entities.Exam>().SoftDeleteAsync(result, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}