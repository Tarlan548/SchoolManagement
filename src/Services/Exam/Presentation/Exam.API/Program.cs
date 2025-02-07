using Exam.Application;
using Exam.Application.Exception;
using Exam.Persistence;

var builder = WebApplication.CreateBuilder(args);

var env = builder.Environment;

builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.Production.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
await app.RunAsync();
