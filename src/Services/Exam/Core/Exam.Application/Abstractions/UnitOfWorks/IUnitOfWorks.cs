using Exam.Application.Abstractions.Repositorys;
using Exam.Domain.Common;

namespace Exam.Application.Abstractions.UnitOfWorks;

public interface IUnitOfWork
{
    IReadRepository<T> GetReadRepository<T>() where T : class, IEntityBase, new();
    IWriteRepository<T> GetWriteRepository<T>() where T : class, IEntityBase, new();
    Task<int> SaveAsync(CancellationToken cancellationToken);
    int Save();
}