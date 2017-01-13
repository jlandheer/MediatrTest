using System;
using System.Threading.Tasks;
using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Decorators
{
    public class AuthorizationDecorator<TRequest> : ICommandHandler<TRequest> where TRequest : ICommand
    {
        private readonly IAsyncRequestHandler<TRequest, Unit> _next;

        public AuthorizationDecorator(IAsyncRequestHandler<TRequest, Unit> next)
        {
            _next = next;
        }

        public Task<Unit> Handle(TRequest message)
        {
            return _next.Handle(message);
        }
    }
}