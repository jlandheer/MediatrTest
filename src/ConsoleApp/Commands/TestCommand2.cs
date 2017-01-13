using ConsoleApp.Infrastructure;
using MediatR;

namespace ConsoleApp.Commands
{
    public class TestCommand2 : ICommand
    {
        public string Message { get; set; }
    }
}