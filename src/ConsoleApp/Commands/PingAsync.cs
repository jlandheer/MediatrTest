using ConsoleApp.Infrastructure;

namespace ConsoleApp.Commands
{
    public class PingAsync : AsyncCommand
    {
        public string Message { get; set; }
    }
}