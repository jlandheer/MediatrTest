using System.Threading.Tasks;
using ConsoleApp.Commands;
using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Handlers
{
    public class TestCommand2Handler : ICommandHandler<TestCommand2>
    {
        public Task<Unit> Handle(TestCommand2 message)
        {
            return Unit.Task;
        }
    }
}