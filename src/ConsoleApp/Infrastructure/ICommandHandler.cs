using MediatR;

namespace ConsoleApp.Infrastructure
{
    public interface ICommandHandler<in TRequest> : IAsyncRequestHandler<TRequest, Unit> where TRequest : ICommand
    {
    }
}