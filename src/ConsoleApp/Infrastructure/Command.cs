using MediatR;

namespace ConsoleApp.Infrastructure
{
    public abstract class Command : IRequest<CommandResult>
    {
    }
}