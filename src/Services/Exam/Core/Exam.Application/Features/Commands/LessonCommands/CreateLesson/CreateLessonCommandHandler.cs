using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.LessonCommands.CreateLesson;

public class CreateLessonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateLessonCommandRequest, Unit>
{
    public async Task<Unit> Handle(CreateLessonCommandRequest request, CancellationToken cancellationToken)
    {
        var map = mapper.Map<CreateLessonCommandRequest, Lesson>(request);
        await unitOfWork.GetWriteRepository<Lesson>().AddAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}
