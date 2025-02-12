using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.StudentCommands.UpdateStudent;

public class UpdateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateStudentCommandRequest, Unit>
{
    public async Task<Unit> Handle(UpdateStudentCommandRequest request, CancellationToken cancellationToken)
    {
        _ = await unitOfWork.GetReadRepository<Student>().GetAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Student");
        var map = mapper.Map<UpdateStudentCommandRequest, Student>(request);
        await unitOfWork.GetWriteRepository<Student>().UpdateAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}
