using ConsoleApp.Commands;
using ConsoleApp.Infrastructure;

namespace ConsoleApp.Handlers
{
    public class TestCommand2Handler : CommandHandler<TestCommand2>
    {
        public override CommandResult Handle(TestCommand2 message)
        {
            return new CommandResult();
        }
    }
}