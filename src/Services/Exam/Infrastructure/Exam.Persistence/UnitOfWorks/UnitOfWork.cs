using Exam.Application.Abstractions.Repositorys;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Persistence.Context;
using Exam.Persistence.Repositories;
using System;

namespace Exam.Persistence.UnitOfWorks;

public class UnitOfWork(SchoolDbContext context) : IUnitOfWork
{
    public async ValueTask DisposeAsync() => await context.DisposeAsync();
    public int Save() => context.SaveChanges();
    public async Task<int> SaveAsync(CancellationToken cancellationToken) => await context.SaveChangesAsync(cancellationToken);
    IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(context);
    IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(context);
}