using System.Threading.Tasks;
using ConsoleApp.Commands;
using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Handlers
{
    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public Task<Unit> Handle(TestCommand message)
        {
            return Unit.Task;
        }
    }
}