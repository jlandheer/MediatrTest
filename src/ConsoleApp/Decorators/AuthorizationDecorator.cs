using System;
using System.Threading.Tasks;
using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Decorators
{
    public class AuthorizationDecorator<TRequest> : ICommandHandler<TRequest> where TRequest : ICommand
    {
        private readonly IAsyncRequestHandler<TRequest, CommandResult> _next;

        public AuthorizationDecorator(IAsyncRequestHandler<TRequest, CommandResult> next)
        {
            _next = next;
        }

        public Task<CommandResult> Handle(TRequest message)
        {
            return _next.Handle(message);
        }
    }
}