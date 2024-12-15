using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.StudentCommands.DeleteStudent;

public class DeleteStudentCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteStudentCommandRequest, Unit>
{
    public async Task<Unit> Handle(DeleteStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Student>().GetAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Student");
        await unitOfWork.GetWriteRepository<Student>().SoftDeleteAsync(result, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}