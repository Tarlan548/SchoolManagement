using AutoMapper;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Application.Exception.Models;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Commands.TeacherCommands.UpdateTeacher;

public class UpdateTeacherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateTeacherCommandRequest, Unit>
{
    public async Task<Unit> Handle(UpdateTeacherCommandRequest request, CancellationToken cancellationToken)
    {
        _ = await unitOfWork.GetReadRepository<Teacher>().GetAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Teacher");
        var map = mapper.Map<UpdateTeacherCommandRequest, Teacher>(request);
        await unitOfWork.GetWriteRepository<Teacher>().UpdateAsync(map, cancellationToken);
        await unitOfWork.SaveAsync(cancellationToken);
        return Unit.Value;
    }
}