using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.TeacherCommands.DeleteTeacher;

public class DeleteTeacherCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteTeacherCommandRequest, Unit>
{
    public async Task<Unit> Handle(DeleteTeacherCommandRequest request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.GetReadRepository<Teacher>().GetAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Teacher");
        await unitOfWork.GetWriteRepository<Teacher>().SoftDeleteAsync(result, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}