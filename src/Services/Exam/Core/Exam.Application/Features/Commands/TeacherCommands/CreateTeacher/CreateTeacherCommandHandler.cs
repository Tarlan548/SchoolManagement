using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.TeacherCommands.CreateTeacher;

public class CreateTeacherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateTeacherCommandRequest, Unit>
{
    public async Task<Unit> Handle(CreateTeacherCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<CreateTeacherCommandRequest, Teacher>(request);
        await unitOfWork.GetWriteRepository<Teacher>().AddAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}