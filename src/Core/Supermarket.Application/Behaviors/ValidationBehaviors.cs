
using FluentValidation;
using MediatR;
using Supermarket.Application.Abstractions.Messaging;
using ValidationException = Supermarket.Application.Exceptions.ValidationException;

namespace Supermarket.Application.Behaviors
{
    public sealed class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorDictionary = _validators
                .Select(x => x.Validate(context))
                .SelectMany(x => x.Errors)
                .Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessage) =>
                        new
                        {
                            Key = propertyName,
                            Values = errorMessage.Distinct().ToArray()
                        })
                .ToDictionary(x =>x.Key, x => x.Values);
            if (errorDictionary.Any())
            {
                throw new ValidationException(errorDictionary);
            }
            return await next();
        }
    }
}