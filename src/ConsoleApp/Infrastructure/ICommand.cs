using MediatR;

namespace ConsoleApp.Infrastructure
{
    public interface ICommand : IRequest<CommandResult>
    {
    }
}