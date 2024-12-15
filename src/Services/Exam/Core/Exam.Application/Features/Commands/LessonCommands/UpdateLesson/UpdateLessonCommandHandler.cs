using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.LessonCommands.UpdateLesson;

public class UpdateLessonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateLessonCommandRequest, Unit>
{
    public async Task<Unit> Handle(UpdateLessonCommandRequest request, CancellationToken cancellationToken)
    {
        _ = await unitOfWork.GetReadRepository<Lesson>().GetAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Lesson");
        var map = mapper.Map<UpdateLessonCommandRequest, Lesson>(request);
        await unitOfWork.GetWriteRepository<Lesson>().UpdateAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}