using Exam.Application.Abstractions.Repositorys;
using Exam.Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Exam.Persistence.Context;
using Exam.Application.DTOs;

namespace Exam.Persistence.Repositories;

public class ReadRepository<T>(SchoolDbContext _appDbContext) : IReadRepository<T> where T : class, IEntityBase, new()
{
    private DbSet<T> Table { get => _appDbContext.Set<T>(); }
    public async Task<PagedResult<T>> GetAllPagingQueryableAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool enableTracking = false,
        int? currentPage = null,
        int? pageSize = null)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();

        if (include is { }) queryable = include(queryable);

        if (predicate is { }) queryable = queryable.Where(predicate);

        int totalCount = await queryable.CountAsync();
        Page paging = new(currentPage ?? 1, pageSize ?? 10, totalCount);

        if (orderBy is { }) queryable = orderBy(queryable);

        var data = await queryable
            .Skip(paging.Skip)
            .Take(paging.PageSize)
            .ToListAsync();

        return new PagedResult<T>(data, paging);
    }
    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is { }) queryable = include(queryable);
        if (predicate is { }) queryable = queryable.Where(predicate);
        if (orderBy is { })
            return await orderBy(queryable).ToListAsync();

        return await queryable.ToListAsync();
    }


    public async Task<T> GetAsync(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is { }) queryable = include(queryable);

        return (await queryable.FirstOrDefaultAsync(predicate!))!;
    }

}