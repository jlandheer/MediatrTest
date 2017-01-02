using System;
using System.Linq;
using ConsoleApp.Infrastructure;
using FluentValidation;
using MediatR;

namespace ConsoleApp.Decorators
{
    public class ValidationDecorator<TRequest> : CommandHandler<TRequest> where TRequest : Command
    {
        private readonly IRequestHandler<TRequest, CommandResult> _next;
        private readonly IValidator<TRequest>[] _validators;

        public ValidationDecorator(IRequestHandler<TRequest, CommandResult> next, IValidator<TRequest>[] validators)
        {
            _next = next;
            _validators = validators;
            Console.WriteLine($"Init Validation met {validators.Length} validators");
        }

        public override CommandResult Handle(TRequest message)
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
                return new CommandResult(failures.Select(i => i.ErrorMessage));
            }

            return _next.Handle(message);
        }
    }
}