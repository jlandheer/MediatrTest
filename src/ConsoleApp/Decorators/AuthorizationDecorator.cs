using System;
using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Decorators
{
    public class AuthorizationDecorator<TRequest> : CommandHandler<TRequest> where TRequest : Command
    {
        private readonly IRequestHandler<TRequest, CommandResult> _next;

        public AuthorizationDecorator(IRequestHandler<TRequest, CommandResult> next)
        {
            _next = next;
        }

        public override CommandResult Handle(TRequest message)
        {
            Console.WriteLine($"Authorizing Ping ({typeof(TRequest)})");

            return _next.Handle(message);
        }
    }
}