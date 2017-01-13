using System.Threading.Tasks;
using ConsoleApp.Commands;
using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Handlers
{
    public class TestCommand2Handler : /*ICommandHandler<TestCommand2>, */
        IAsyncRequestHandler<TestCommand2, CommandResult>
    {
        public Task<CommandResult> Handle(TestCommand2 message)
        {
            return CommandResult.SuccesTask;
        }
    }
}