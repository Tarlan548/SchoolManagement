using Exam.Application.Abstractions.Repositorys;
using Exam.Application.Abstractions.UnitOfWorks;
using Exam.Persistence.Context;
using Exam.Persistence.Repositories;
using Exam.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SchoolDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString("mssql-connection"));
        });

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}