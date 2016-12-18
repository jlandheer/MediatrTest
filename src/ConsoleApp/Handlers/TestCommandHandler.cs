using ConsoleApp.Commands;
using ConsoleApp.Infrastructure;

namespace ConsoleApp.Handlers
{
    public class TestCommandHandler : CommandHandler<TestCommand>
    {
        public override CommandResult Handle(TestCommand message)
        {
            return new CommandResult();
        }
    }
}