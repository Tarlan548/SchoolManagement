using Exam.Application.Abstractions.Repositorys;
using Exam.Domain.Common;
using Exam.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Exam.Persistence.Repositories;

public class WriteRepository<T>(SchoolDbContext _appDbContext) : IWriteRepository<T> where T : class, IEntityBase, new()
{
    private DbSet<T> Table { get => _appDbContext.Set<T>(); }
    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await Table.AddAsync(entity, cancellationToken);
    }
    public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        entity.ModifiedDate = DateTime.UtcNow;
        await Task.Run(() => Table.Update(entity), cancellationToken);
        return entity;
    }
    public async Task SoftDeleteAsync(T entity, CancellationToken cancellationToken)
    {
        entity.ModifiedDate = DateTime.UtcNow;
        entity.IsDeleted = true;
        await Task.Run(() => Table.Update(entity), cancellationToken);
    }
}