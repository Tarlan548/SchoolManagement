using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Serilog;
using FluentValidation;

namespace Exam.Application.Exception;

public class ExceptionMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        ValidateParameters(context);
        await ExecuteMiddlewareAsync(context, next);
    }

    private static void ValidateParameters(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
    }

    private static async Task ExecuteMiddlewareAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (System.Exception ex)
        {
            string messageTemplate = $"{ex.Message}";
            Log.Error(ex, messageTemplate);
            await HandleExceptionAsync(context, ex);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext httpContext, System.Exception exception)
    {
        int statusCode = GetStatusCode(exception);

        var problemDetails = new ProblemDetails
        {
            Title = "An error occurred",
            Status = statusCode,
            Detail = exception.Message,
        };

        if (exception is ValidationException validationException)
        {
            problemDetails.Title = "Validation Error";
            problemDetails.Detail = "One or more validation errors occurred.";
            problemDetails.Extensions["errors"] = validationException.Errors.Select(x => x.ErrorMessage).ToArray();
        }

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }

    private static int GetStatusCode(System.Exception exception)
    {
        return exception switch
        {
            BadHttpRequestException => StatusCodes.Status400BadRequest,
            FluentValidation.ValidationException => StatusCodes.Status422UnprocessableEntity,
            _ => StatusCodes.Status500InternalServerError,
        };
    }
}