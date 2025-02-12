using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using MediatR;

namespace Exam.Application.Features.Commands.ExamCommands.UpdateExam;

public class UpdateExamCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateExamCommandRequest, Unit>
{
    public async Task<Unit> Handle(UpdateExamCommandRequest request, CancellationToken cancellationToken)
    {
        _ = await unitOfWork.GetReadRepository<Domain.Entities.Exam>().GetAsync(x => x.Id == Guid.Parse(request.Id)) ?? throw new NotFoundException("Exam");
        var map = mapper.Map<UpdateExamCommandRequest, Domain.Entities.Exam>(request);
        await unitOfWork.GetWriteRepository<Domain.Entities.Exam>().UpdateAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}