using System.Threading.Tasks;
using ConsoleApp.Commands;
using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Handlers
{
    public class PingAsyncHandler : AsyncCommandHandler<PingAsync>
    {
        public override Task<CommandResult> Handle(PingAsync message)
        {
            System.Console.WriteLine($"PingAsyncHandler: {message.Message}");
            return Task.FromResult(new CommandResult());
        }
    }
}