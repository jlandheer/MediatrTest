using MediatR;

namespace ConsoleApp.Infrastructure
{
    public abstract class AsyncCommand : IAsyncRequest<CommandResult>
    {
    }
}