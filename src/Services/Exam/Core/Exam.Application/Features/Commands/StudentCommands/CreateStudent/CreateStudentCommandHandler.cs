using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.StudentCommands.CreateStudent;

public class CreateStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateStudentCommandRequest, Unit>
{
    public async Task<Unit> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<CreateStudentCommandRequest, Student>(request);
        await unitOfWork.GetWriteRepository<Student>().AddAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}