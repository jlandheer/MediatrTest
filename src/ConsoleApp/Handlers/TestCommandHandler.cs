using System.Threading.Tasks;
using ConsoleApp.Commands;
using ConsoleApp.Infrastructure;

namespace ConsoleApp.Handlers
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public Task<CommandResult> Handle(TestCommand message)
        {
            return CommandResult.SuccesTask;
        }
    }
}