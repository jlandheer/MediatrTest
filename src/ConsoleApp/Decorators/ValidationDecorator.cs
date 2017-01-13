using System;
using System.Linq;
using System.Threading.Tasks;
using ConsoleApp.Infrastructure;
using FluentValidation;
using MediatR;

namespace ConsoleApp.Decorators
{
    public class ValidationDecorator<TRequest> : ICommandDecorator<TRequest> where TRequest : ICommand
    {
        private readonly IAsyncRequestHandler<TRequest, Unit> _next;
        private readonly IValidator<TRequest>[] _validators;

        public ValidationDecorator(IAsyncRequestHandler<TRequest, Unit> next, IValidator<TRequest>[] validators)
        {
            _next = next;
            _validators = validators;
            Console.WriteLine($"Init Validation met {validators.Length} validators");
        }

        public Task<Unit> Handle(TRequest message)
        {
            Console.WriteLine($"Validating ({typeof(TRequest)}) with {_validators.Length} validators");
            var context = new ValidationContext(message);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return _next.Handle(message);
        }
    }
}