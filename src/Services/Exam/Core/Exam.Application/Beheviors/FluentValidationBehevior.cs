using FluentValidation;
using MediatR;

namespace Exam.Application.Beheviors;

public class FluentValidationBehevior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validator)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var failtures = validator
            .Select(x => x.Validate(context))
            .SelectMany(result => result.Errors)
            .GroupBy(x => x.ErrorMessage)
            .Select(x => x.First())
            .Where(f => f != null)
            .ToList();

        return failtures.Count != 0 ? throw new ValidationException(failtures) : next();
    }
}
