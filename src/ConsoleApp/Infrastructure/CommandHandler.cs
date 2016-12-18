using MediatR;

namespace ConsoleApp.Infrastructure
{
    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest, CommandResult> where TRequest : Command
    {
        public abstract CommandResult Handle(TRequest message);
    }
}