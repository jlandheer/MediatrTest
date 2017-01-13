using MediatR;

namespace ConsoleApp.Infrastructure
{
    public interface ICommandHandler<in TRequest> : IAsyncRequestHandler<TRequest, CommandResult> where TRequest : ICommand
    {
    }
    public interface ICommandDecorator<in TRequest> : IAsyncRequestHandler<TRequest, CommandResult> where TRequest : ICommand
    {
    }
}