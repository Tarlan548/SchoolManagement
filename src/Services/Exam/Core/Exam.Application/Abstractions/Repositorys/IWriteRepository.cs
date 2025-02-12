using Exam.Domain.Common;

namespace Exam.Application.Abstractions.Repositorys;

public interface IWriteRepository<T> where T : class, IEntityBase, new()
{
    Task AddAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
    Task SoftDeleteAsync(T entity, CancellationToken cancellationToken);
}