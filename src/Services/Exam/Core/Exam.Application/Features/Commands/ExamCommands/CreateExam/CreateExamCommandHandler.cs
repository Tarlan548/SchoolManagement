using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using MediatR;

namespace Exam.Application.Features.Commands.ExamCommands.CreateExam;

public class CreateExamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateExamCommandRequest, Unit>
{
    public async Task<Unit> Handle(CreateExamCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<CreateExamCommandRequest, Domain.Entities.Exam>(request);
        await unitOfWork.GetWriteRepository<Domain.Entities.Exam>().AddAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}