using ConsoleApp.Infrastructure;

namespace ConsoleApp.Commands
{
    public class TestCommand : ICommand
    {
        public string Message { get; set; }
    }
}