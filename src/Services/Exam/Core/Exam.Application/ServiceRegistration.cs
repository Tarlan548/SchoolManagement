using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Globalization;
using Exam.Application.Beheviors;
using Exam.Application.Exception;
using AutoMapper;

namespace Exam.Application;

public static class ServiceRegistration
{
    public static void AddApplicationRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(assembly);
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
        });

        IMapper mapper = mapperConfig.CreateMapper();


        services.AddSingleton(mapper);
        services.AddTransient<ExceptionMiddleware>();
        services.AddValidatorsFromAssemblies([assembly]);

        string culture = configuration["FluentValidation:Culture"] ?? "en";
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo(culture);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
    }
}