using System.Threading.Tasks;
using MediatR;

namespace ConsoleApp.Infrastructure
{
    public abstract class AsyncCommandHandler<TRequest> : IAsyncRequestHandler<TRequest, CommandResult> where TRequest : AsyncCommand
    {
        public abstract Task<CommandResult> Handle(TRequest message);
    }
}