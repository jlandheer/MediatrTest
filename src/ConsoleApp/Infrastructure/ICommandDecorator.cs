using MediatR;

namespace ConsoleApp.Infrastructure
{
    public interface ICommandDecorator<in TRequest> : IAsyncRequestHandler<TRequest, Unit> where TRequest : ICommand
    {
    }
}